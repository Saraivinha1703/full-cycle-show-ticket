using Caticket.SalesAPI.Identity.DTOs.Request;
using Caticket.SalesAPI.Identity.DTOs.Response;
using Caticket.SalesAPI.Domain.Entities;
using Caticket.SalesAPI.Identity.Entities;
using System.Security.Claims;

namespace Caticket.SalesAPI.Application.Interfaces.Services;

public interface IIdentityService {
    Task<UserSignUpResponse> SignUpAsync(UserSignUpRequest userDto, bool isPartner = false);
    
    Task<UserLoginResponse> LoginAsync(UserLoginRequest userDto);

    Task<User> GetUserFromTokenAsync(string token, ClaimsPrincipal claimsPrincipal);
    Guid GetUserIdFromToken(string token);
}