using Caticket.SalesAPI.Application.Interfaces.Services;
using Caticket.SalesAPI.Identity.Services;
using Microsoft.Extensions.Primitives;

namespace Caticket.SalesAPI.Web.Services;
public sealed class UserProvider(IHttpContextAccessor httpContextAccessor, IIdentityService identityService) {
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
    private readonly IIdentityService _identityService = identityService;

    public Guid? GetUserId() {
        StringValues? userIdHeader = _httpContextAccessor.HttpContext?.Request.Headers.Authorization;
        
        if(userIdHeader is null || string.IsNullOrEmpty(userIdHeader.Value)) 
            return null;

        return _identityService.GetUserIdFromToken(userIdHeader.Value.ToString().Split("Bearer ")[1]);
    }
}