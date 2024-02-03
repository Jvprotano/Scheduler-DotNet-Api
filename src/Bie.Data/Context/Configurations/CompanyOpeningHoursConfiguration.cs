using Bie.Data.Context.Configurations.Base;
using Bie.Business.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bie.Data.Context.Configurations;
public class CompanyOpeningHoursConfiguration : EntityBaseConfiguration<CompanyOpeningHours>
{
    public override void Configure(EntityTypeBuilder<CompanyOpeningHours> builder)
    {
        base.Configure(builder);
    }
}