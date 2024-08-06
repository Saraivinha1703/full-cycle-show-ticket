using Caticket.PartnerAPI.Domain.Entities;
using Caticket.PartnerAPI.Domain.Enumerators;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Caticket.PartnerAPI.Infrastructure.Mappers;

public class TicketMap {
    public TicketMap(EntityTypeBuilder<Ticket> entityBuilder) {
        entityBuilder.HasKey(t => t.Id);
        entityBuilder.Property(t => t.Email).IsRequired();
        entityBuilder.HasOne(t => t.Spot);
        entityBuilder.Property(t => t.TicketType)
            .HasConversion(
                t => t.Id, 
                id => Enumeration.From<TicketType>(id)
            );
    }
}