using Caticket.PartnerAPI.Domain.Entities;
using Caticket.PartnerAPI.Domain.Enumerators;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Caticket.PartnerAPI.Infrastructure.Mappers;

public class ReservationHistoryMap {
    public ReservationHistoryMap(EntityTypeBuilder<ReservationHistory> entityBuilder) {
        entityBuilder.HasKey(e => e.Id);
        entityBuilder.Property(e => e.Email).IsRequired();
        entityBuilder.Property(t => t.TicketType)
            .HasConversion(
                t => t.Id, 
                id => Enumeration.From<TicketType>(id)
            );
    }
}