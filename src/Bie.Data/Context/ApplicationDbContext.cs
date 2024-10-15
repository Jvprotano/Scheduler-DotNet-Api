using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

using Bie.Business.Models;
using Bie.Business.Models.Base;
using Bie.Data.Context.Extensions;

namespace Bie.Data.Context;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        modelBuilder.ApplySnakeCaseNamingConvention();

        base.OnModelCreating(modelBuilder);
    }
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        UpdateDefaultValues();
        return await base.SaveChangesAsync(cancellationToken);
    }
    private void UpdateDefaultValues()
    {
        var entries = ChangeTracker.Entries().Where(e => e.Entity is EntityBase && (
    e.State == EntityState.Added || e.State == EntityState.Modified));

        // TODO: Check if is needed
        // foreach (var entry in entries)
        // {
        //     var entity = (EntityBase)entry.Entity;
        //     var now = DateTime.UtcNow;

        //     if (entry.State == EntityState.Added)
        //         entity.CreatedAt = now;

        //     if (!entity.Status.HasValue)
        //         entity.Status = Bie.Business.Enums.StatusEnum.Active;

        //     entity.UpdatedAt = now;
        // }
    }
}