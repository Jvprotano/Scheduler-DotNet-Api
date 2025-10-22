using Agende.Data.Context.Configurations.Base;
using Agende.Business.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agende.Data.Context.Configurations;
public class CompanyOpeningHoursConfiguration : EntityBaseConfiguration<CompanyOpeningHours>
{
    public override void Configure(EntityTypeBuilder<CompanyOpeningHours> builder)
    {
        base.Configure(builder);
    }
}