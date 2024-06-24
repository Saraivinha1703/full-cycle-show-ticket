using Caticket.PartnerAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Caticket.PartnerAPI.Infrastructure.Mappers;

public class SpotMap {
    public SpotMap(EntityTypeBuilder<Spot> entityBuilder) {
        entityBuilder.HasKey(e => e.Id);
        entityBuilder.Property(e => e.Name).IsRequired();
    }
}