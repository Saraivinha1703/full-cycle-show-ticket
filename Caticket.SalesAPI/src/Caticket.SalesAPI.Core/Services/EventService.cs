using System.Net.Http.Json;
using System.Text;
using Caticket.SalesAPI.Core.Configuration;
using Caticket.SalesAPI.Core.DTOs.Partner;
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

    public async Task<Event[]> ListEvents(Guid tenantId) {
        HttpClient httpClient = new();

        StringBuilder stringBuilder = new(_partnerInfo.BaseURL);
        stringBuilder.Append("/events");

        httpClient.DefaultRequestHeaders.Add(PartnerInfo.TenantIdHTTPHeaderName, tenantId.ToString());

        Event[] events = await httpClient.GetFromJsonAsync<Event[]>(stringBuilder.ToString()) 
            ?? throw new PartnerServiceException("GET /all-events", "Nothing was returned from the API.");
        
        return events;
    }

    public async Task<CreateEventResponse> CreateEvent(Guid tenantId, CreateEventRequest createEventRequest) {
        HttpClient httpClient = new();

        StringBuilder stringBuilder = new(_partnerInfo.BaseURL);
        stringBuilder.Append("/events");

        httpClient.DefaultRequestHeaders.Add(PartnerInfo.TenantIdHTTPHeaderName, tenantId.ToString());

        HttpResponseMessage response = await httpClient.PostAsJsonAsync(stringBuilder.ToString(), createEventRequest);

        CreateEventResponse content = await response.Content.ReadFromJsonAsync<CreateEventResponse>() ?? throw new PartnerServiceException("POST /events", "Something went wrong while creating the event.");

        return content;
    }
} 