using Bie.Business.Models;
using Bie.Data.Context.Configurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bie.Data.Context.Configurations;
public class CompanyEmployeeConfiguration : EntityBaseConfiguration<CompanyEmployee>
{
    public override void Configure(EntityTypeBuilder<CompanyEmployee> builder)
    {
        base.Configure(builder);

        builder.ToTable("company_employees");

        builder.HasOne(x => x.Company)
            .WithMany(x => x.Employeers)
            .HasForeignKey(x => x.CompanyId);
    }

}