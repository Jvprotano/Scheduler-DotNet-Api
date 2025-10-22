using Agende.Business.Enums;
using Agende.Business.Models;
using Agende.Data.Context.Configurations.Base;
using Microsoft.EntityFrameworkCore;

using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agende.Data.Context.Configurations;
public class CompanyConfiguration : ProfileBaseConfiguration<Company>
{
    public override void Configure(EntityTypeBuilder<Company> builder)
    {
        base.Configure(builder);

        builder.Property(c => c.ScheduleStatus)
            .HasDefaultValue(ScheduleStatusEnum.Closed);

        builder.HasMany(c => c.Employeers)
            .WithOne(c => c.Company)
            .HasForeignKey(c => c.CompanyId);

        builder.HasMany(c => c.ServicesOffered)
            .WithOne(c => c.Company)
            .HasForeignKey(c => c.CompanyId);
    }
}