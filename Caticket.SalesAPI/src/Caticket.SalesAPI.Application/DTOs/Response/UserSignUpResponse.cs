using Caticket.SalesAPI.Application.Interfaces.DTOs;

namespace Caticket.SalesAPI.Application.DTOs.Response;

public class UserSignUpResponse : BaseResponse, IResponse {
    public UserSignUpResponse(bool success) => Success = success;
}