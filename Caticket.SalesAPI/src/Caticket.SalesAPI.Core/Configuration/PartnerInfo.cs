namespace Caticket.SalesAPI.Core.Configuration;

public class PartnerInfo {
    public required string BaseURL { get; set; }
    public const string TenantIdHTTPHeaderName = "X-TenantId";
}