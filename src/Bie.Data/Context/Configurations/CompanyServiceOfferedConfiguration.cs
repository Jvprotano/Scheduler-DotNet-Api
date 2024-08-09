using Bie.Data.Context.Configurations.Base;
using Bie.Business.Models;

using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bie.Data.Context.Configurations;
public class CompanyServiceOfferedConfiguration : EntityBaseConfiguration<CompanyServiceOffered>
{
    public override void Configure(EntityTypeBuilder<CompanyServiceOffered> builder)
    {
        base.Configure(builder);

        builder.HasOne(c => c.Company)
            .WithMany(c => c.ServicesOffered)
            .HasForeignKey(c => c.CompanyId);
    }
}