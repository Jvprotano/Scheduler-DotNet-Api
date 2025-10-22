using Agende.Business.Models;
using Agende.Data.Context.Configurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agende.Data.Context.Configurations;
public class CompanyEmployeeConfiguration : EntityBaseConfiguration<CompanyEmployee>
{
    public override void Configure(EntityTypeBuilder<CompanyEmployee> builder)
    {
        base.Configure(builder);

        builder.ToTable("company_employees");

        builder.Property(c => c.IsOwner)
         .HasDefaultValue(false);

        builder.HasOne(x => x.Company)
            .WithMany(x => x.Employeers)
            .HasForeignKey(x => x.CompanyId);
    }

}