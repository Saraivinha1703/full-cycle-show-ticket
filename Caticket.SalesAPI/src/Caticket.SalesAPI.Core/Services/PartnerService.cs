using System.Net.Http.Json;
using System.Text;
using Caticket.SalesAPI.Core.DTOs.Request;
using Caticket.SalesAPI.Core.DTOs.Response;
using Caticket.SalesAPI.Domain.Enumerators;

namespace Caticket.SalesAPI.Core.Services;

public class PartnerService {
    //const string BaseURL = "http://partner-app:5000";
    const string BaseURL = "http://localhost:5001";
    
    public async Task<Tuple<List<string>, List<ReservationResponse>?>> MakeReservation(ReservationRequest reservationRequest) {
        PartnerReservationRequest partnerReservationRequest = new() {
            Email = reservationRequest.Email,
            TicketKind = reservationRequest.TicketType,
            Spots = reservationRequest.Spots
        };

        HttpClient httpClient = new();
        StringBuilder stringBuilder = new(BaseURL);

        stringBuilder
            .Append("/events/")
            .Append(reservationRequest.EventId)
            .Append("/reserve");

        HttpResponseMessage response = await httpClient.PostAsJsonAsync(stringBuilder.ToString(), partnerReservationRequest);

        if(!response.IsSuccessStatusCode) throw new Exception("Reservation Error: error while calling partner API to reserve spots");

        PartnerReservationResponse content = await response.Content.ReadFromJsonAsync<PartnerReservationResponse>() 
            ?? throw new Exception("Reservation Error: error while converting partner API response");

        if(content.Item2 == null) {
            return new(["Fail during reservation"], null);
        }

        IEnumerable<ReservationResponse> reservationResponse = content.Item2.Select(res => 
            new ReservationResponse() {
                Id = res.Id,
                Spot = res.Spot.Name,
                Status = Enumeration.From<SpotStatus>(res.Spot.Status), 
            }
        );

        return new([], reservationResponse.ToList());
    }
} 