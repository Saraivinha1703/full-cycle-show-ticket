using Caticket.SalesAPI.Identity.Interfaces.DTOs;

namespace Caticket.SalesAPI.Identity.DTOs.Response;

public class UserSignUpResponse : BaseResponse, IResponse {
    public UserSignUpResponse(bool success) => Success = success;
}