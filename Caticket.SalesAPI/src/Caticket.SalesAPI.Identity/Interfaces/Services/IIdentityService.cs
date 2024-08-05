using Caticket.SalesAPI.Identity.DTOs.Request;
using Caticket.SalesAPI.Identity.DTOs.Response;
using Caticket.SalesAPI.Domain.Entities;
using Caticket.SalesAPI.Identity.Entities;

namespace Caticket.SalesAPI.Application.Interfaces.Services;

public interface IIdentityService {
    Task<UserSignUpResponse> SignUpAsync(UserSignUpRequest userDto, bool isPartner = false);
    
    Task<UserLoginResponse> LoginAsync(UserLoginRequest userDto);

    Task<User> GetUserFromTokenAsync(string token);
    Guid GetUserIdFromToken(string token);
}