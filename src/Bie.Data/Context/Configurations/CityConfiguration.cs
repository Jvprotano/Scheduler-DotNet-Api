using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Bie.Business.Models;
using Bie.Data.Context.Configurations.Base;

namespace Bie.Data.Context.Configurations;
public class CityConfiguration : EntityBaseConfiguration<City>
{
    public override void Configure(EntityTypeBuilder<City> builder)
    {
        base.Configure(builder);

        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(c => c.Country)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(c => c.State)
        .IsRequired()
        .HasMaxLength(50);
    }
}