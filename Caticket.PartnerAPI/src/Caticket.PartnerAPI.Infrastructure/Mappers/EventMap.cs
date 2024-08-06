using Caticket.PartnerAPI.Domain.Entities;
using Caticket.PartnerAPI.Domain.Enumerators;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Caticket.PartnerAPI.Infrastructure.Mappers;

public class EventMap {
    public EventMap(EntityTypeBuilder<Event> entityBuilder) {
        entityBuilder.HasKey(e => e.Id);
        entityBuilder.Property(e => e.Name).IsRequired();
        entityBuilder.Property(e => e.Rating)
            .HasConversion(
                e => e.Id, 
                id => Enumeration.From<Rating>(id)
            );
    }
}