using System.Net.Http.Json;
using System.Text;
using Caticket.SalesAPI.Core.Configuration;
using Caticket.SalesAPI.Core.Exceptions;
using Caticket.SalesAPI.Domain.Entities;
using Microsoft.Extensions.Options;

namespace Caticket.SalesAPI.Core.Services;

public class EventService(IOptions<PartnerInfo> partnerInfo) {

    private readonly PartnerInfo _partnerInfo = partnerInfo.Value;

    public async Task<Event[]> ListAllEvents() {
        HttpClient httpClient = new();

        StringBuilder stringBuilder = new(_partnerInfo.BaseURL);
        stringBuilder.Append("/all-events");

        Event[] events = await httpClient.GetFromJsonAsync<Event[]>(stringBuilder.ToString()) 
            ?? throw new PartnerServiceException("GET /all-events", "Nothing was returned from the API.");
        
        return events;
    }
} 