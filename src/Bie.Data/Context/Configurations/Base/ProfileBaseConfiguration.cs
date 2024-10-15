using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Bie.Business.Models.Base;

namespace Bie.Data.Context.Configurations.Base;
public abstract class ProfileBaseConfiguration<T> : EntityBaseConfiguration<T> where T : ProfileBase
{
    public override void Configure(EntityTypeBuilder<T> builder)
    {
        builder.Ignore(c => c.ImageBase64);

        base.Configure(builder);
    }
}