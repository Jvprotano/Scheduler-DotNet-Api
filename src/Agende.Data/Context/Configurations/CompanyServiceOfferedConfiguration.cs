using Agende.Data.Context.Configurations.Base;
using Agende.Business.Models;

using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agende.Data.Context.Configurations;
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