using Bie.Business.Models;
using Bie.Data.Context.Configurations.Base;

using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bie.Data.Context.Configurations;
public class CompanyConfiguration : ProfileBaseConfiguration<Company>
{
    public override void Configure(EntityTypeBuilder<Company> builder)
    {
        base.Configure(builder);

        builder.HasMany(c => c.Owners)
            .WithOne(c => c.Company)
            .HasForeignKey(c => c.CompanyId);

        builder.HasMany(c => c.ServicesOffered)
            .WithOne(c => c.Company)
            .HasForeignKey(c => c.CompanyId);
    }
}