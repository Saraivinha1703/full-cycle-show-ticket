using Caticket.PartnerAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Caticket.PartnerAPI.Infrastructure.Mappers;

public class EventMap {
    public EventMap(EntityTypeBuilder<Event> entityBuilder) {
        entityBuilder.HasKey(e => e.Id);
        entityBuilder.Property(e => e.Name).IsRequired();
    }
}