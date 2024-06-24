using Caticket.PartnerAPI.Domain.Interfaces.DTO.Spot;

namespace Caticket.PartnerAPI.Web.DTO.Spot;

public record CreateSpotDto(string Name) : ICreateSpotDto;