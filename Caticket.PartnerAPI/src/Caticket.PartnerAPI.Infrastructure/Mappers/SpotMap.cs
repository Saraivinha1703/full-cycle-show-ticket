using Caticket.PartnerAPI.Domain.Entities;
using Caticket.PartnerAPI.Domain.Enumerators;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Caticket.PartnerAPI.Infrastructure.Mappers;

public class SpotMap {
    public SpotMap(EntityTypeBuilder<Spot> entityBuilder) {
        entityBuilder.HasKey(s => s.Id);
        entityBuilder.Property(s => s.Name).IsRequired();
        entityBuilder.HasOne(s => s.Event);
        entityBuilder.Property(s => s.SpotStatus)
            .HasConversion(
                e => e.Id, 
                id => Enumeration.From<SpotStatus>(id)
            );
    }
}