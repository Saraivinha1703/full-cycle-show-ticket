using Caticket.PartnerAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Caticket.PartnerAPI.Infrastructure.Mappers;

public class ReservationHistoryMap {
    public ReservationHistoryMap(EntityTypeBuilder<ReservationHistory> entityBuilder) {
        entityBuilder.HasKey(e => e.Id);
        entityBuilder.Property(e => e.Email).IsRequired();
    }
}