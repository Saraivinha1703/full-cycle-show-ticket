using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Caticket.SalesAPI.Application.DTOs.Request;
using Caticket.SalesAPI.Application.DTOs.Response;
using Caticket.SalesAPI.Application.Interfaces.Services;
using Caticket.SalesAPI.Identity.Configurations;
using Caticket.SalesAPI.Identity.Constants;
using Caticket.SalesAPI.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace Caticket.SalesAPI.Identity.Services;

public class IdentityService(
    SignInManager<User> signInManager,
    UserManager<User> userManager,
    IOptions<JwtOptions> jwtOptions
) : IIdentityService
{
    private readonly SignInManager<User> _signInManager = signInManager;
    private readonly UserManager<User> _userManager = userManager;
    private readonly JwtOptions _jwtOptions = jwtOptions.Value;

    public async Task<UserSignUpResponse> SignUpAsync(UserSignUpRequest userDto, bool isPartner = false)
    {
        User user = new() {
            UserName = userDto.Email,
            Email = userDto.Email,
            //TODO: should be confirmed through a email service 
            EmailConfirmed = true
        };

        IdentityResult result = await _userManager.CreateAsync(user, userDto.Password);
        
        if(result.Succeeded) {
            await _userManager.SetLockoutEnabledAsync(user, false);

            if(isPartner)
                await _userManager.AddToRoleAsync(user, Roles.Partner);
        } 

        UserSignUpResponse userSignUpResponse = new(result.Succeeded);

        if(!result.Succeeded && result.Errors.Any())
            userSignUpResponse.AddErrors(result.Errors.Select(err => err.Description));

        return userSignUpResponse;
    }

    public async Task<UserLoginResponse> LoginAsync(UserLoginRequest userDto)
    {
        var result = await _signInManager.PasswordSignInAsync(userDto.Email, userDto.Password, false, true);
        
        if(result.Succeeded)
            return await GenerateTokenAsync(userDto.Email);

        UserLoginResponse userLoginResponse = new(result.Succeeded);
        
        if(!result.Succeeded) {
            if(result.IsLockedOut) userLoginResponse.AddError("This account is blocked.");
            else if(result.IsNotAllowed) userLoginResponse.AddError("This account do not have permission to login.");
            else if(result.RequiresTwoFactor) userLoginResponse.AddError("You must confirm your login in your second authentication factor.");
            else userLoginResponse.AddError("Email or password wrong.");
        }

        return userLoginResponse;
    }

    // https://datatracker.ietf.org/doc/html/rfc7519
    private async Task<UserLoginResponse> GenerateTokenAsync(string email) {
        User user = await _userManager.FindByEmailAsync(email) ?? throw new Exception("Error during token generation: User not found by the given email.");
        IList<Claim> tokenClaims = await GetClaimsAndRolesAsync(user);

        DateTime expirationDate = DateTime.Now.AddSeconds(_jwtOptions.Expiration);

        JwtSecurityToken jwt = new(
            issuer: _jwtOptions.Issuer,
            audience: _jwtOptions.Audience,
            claims: tokenClaims,
            notBefore: DateTime.Now,
            expires: expirationDate,
            signingCredentials: _jwtOptions.SigningCredentials
        );

        string token = new JwtSecurityTokenHandler().WriteToken(jwt);

        return new UserLoginResponse(
            success: true,
            expirationDate: expirationDate,
            token: token
        );
    }

    private async Task<IList<Claim>> GetClaimsAndRolesAsync(User user) {
        IList<Claim> claims = await _userManager.GetClaimsAsync(user);
        IList<string> roles = await _userManager.GetRolesAsync(user);

        claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id));
        claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email!));
        claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
        claims.Add(new Claim(JwtRegisteredClaimNames.Nbf, DateTime.Now.ToString()));
        claims.Add(new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToString()));

        foreach(string role in roles) 
            claims.Add(new Claim("role", role));

        return claims;
    }
}