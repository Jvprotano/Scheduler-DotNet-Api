using Agende.Business.Models;
using Agende.Data.Context.Configurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agende.Data.Context.Configurations;
public class EmployeeServiceLinkConfiguration : EntityBaseConfiguration<EmployeeServiceLink>
{
    public override void Configure(EntityTypeBuilder<EmployeeServiceLink> builder)
    {
        base.Configure(builder);

        builder.ToTable("employee_services");

        builder.HasOne(c => c.Employee)
            .WithMany(c => c.Services)
            .HasForeignKey(c => c.EmployeeId);
    }
}