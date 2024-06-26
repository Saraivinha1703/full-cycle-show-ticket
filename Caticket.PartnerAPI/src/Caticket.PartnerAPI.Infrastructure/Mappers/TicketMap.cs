using Caticket.PartnerAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Caticket.PartnerAPI.Infrastructure.Mappers;

public class TicketMap {
    public TicketMap(EntityTypeBuilder<Ticket> entityBuilder) {
        entityBuilder.HasKey(t => t.Id);
        entityBuilder.Property(t => t.Email).IsRequired();
        entityBuilder.HasOne(t => t.Spot);
    }
}