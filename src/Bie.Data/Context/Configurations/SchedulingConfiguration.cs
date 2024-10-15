using Bie.Data.Context.Configurations.Base;
using Bie.Business.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bie.Data.Context.Configurations;
public class SchedulingConfiguration : EntityBaseConfiguration<Scheduling>
{
    public override void Configure(EntityTypeBuilder<Scheduling> builder)
    {
        builder.HasOne(c => c.Company)
            .WithMany(c => c.Schedulings)
            .HasForeignKey(c => c.CompanyId).OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(c => c.Customer)
            .WithMany(c => c.Schedulings)
            .HasForeignKey(c => c.CustomerId).OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(c => c.ServiceOffered)
            .WithMany(c => c.Schedulings)
            .HasForeignKey(c => c.ServicesOfferedId).OnDelete(DeleteBehavior.Restrict);

        base.Configure(builder);
    }
}