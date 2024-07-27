using System.Net.Http.Json;
using System.Text;
using Caticket.SalesAPI.Core.DTOs.Request;
using Caticket.SalesAPI.Core.DTOs.Response;

namespace Caticket.SalesAPI.Core.Services;

public class ParterService {
    const string BaseURL = "http://localhost:0000";
    
    public async Task<List<ReservationResponse>> MakeReservation(ReservationRequest reservationRequest) {
        PartnerReservationRequest partnerReservationRequest = new() {
            Email = reservationRequest.Email,
            TicketType = reservationRequest.TicketType,
            Spots = reservationRequest.Spots
        };

        HttpClient httpClient = new();
        StringBuilder stringBuilder = new();

        stringBuilder
            .Append(BaseURL)
            .Append("/events/")
            .Append(reservationRequest.EventId)
            .Append("/reserve");

        var response = await httpClient.PostAsJsonAsync(stringBuilder.ToString(), partnerReservationRequest);

        if(!response.IsSuccessStatusCode) throw new Exception("Reservation Error: error while calling partner API to reseve spots");

        PartnerReservationResponse[] content = await response.Content.ReadFromJsonAsync<PartnerReservationResponse[]>() 
            ?? throw new Exception("Reservation Error: error while converting partner API response");

        IEnumerable<ReservationResponse> reservationResponse = content.Select(res => 
            new ReservationResponse() {
                Id = res.Id,
                //Email = res.Email, 
                Spot = res.Spot, 
                Status = res.Status, 
                //TicketType = res.TicketKind,
                //EventId = res.EventId,
            }
        );

        return reservationResponse.ToList();
    }
} 