
using Caticket.PartnerAPI.Domain.Interfaces.DTO;

namespace Caticket.PartnerAPI.Web.DTO;

public record BaseDeleteDto(Guid Id) : IDeleteDto;