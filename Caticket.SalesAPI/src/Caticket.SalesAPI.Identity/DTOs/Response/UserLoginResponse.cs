using System.Text.Json.Serialization;
using Caticket.SalesAPI.Identity.Interfaces.DTOs;

namespace Caticket.SalesAPI.Identity.DTOs.Response;

public class UserLoginResponse : BaseResponse, IResponse {
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Token { get; private set; } = null;

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public DateTime? ExpirationDate { get; private set; } = null;

    public UserLoginResponse(bool success) => Success = success;

    public UserLoginResponse(bool success, DateTime expirationDate, string token) {
        Success = success;
        ExpirationDate = expirationDate;
        Token = token;
    }
}