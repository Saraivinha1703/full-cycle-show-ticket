using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;

namespace Caticket.PartnerAPI.Core.Services;
public sealed class TenantProvider(IHttpContextAccessor httpContextAccessor) {
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
    private const string TenantIdHeaderName = "X-TenantId";

    public Guid? GetTenantId() {
        StringValues? tenantIdHeader = _httpContextAccessor.HttpContext?.Request.Headers[TenantIdHeaderName];

        if(!tenantIdHeader.HasValue) 
            return null;

        if(!Guid.TryParse(tenantIdHeader.Value, out Guid tenantId)) 
            throw new ApplicationException("Invalid Tenant Id: Error during parse");
        
        return tenantId;
    }
}