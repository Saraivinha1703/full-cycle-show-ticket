using Caticket.SalesAPI.Application.DTOs.Request;
using Caticket.SalesAPI.Application.DTOs.Response;

namespace Caticket.SalesAPI.Application.Interfaces.Services;

public interface IIdentityService {
    Task<UserSignUpResponse> SignUpAsync(UserSignUpRequest userDto, bool isPartner = false);
    
    Task<UserLoginResponse> LoginAsync(UserLoginRequest userDto);
}