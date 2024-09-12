using Microsoft.EntityFrameworkCore;
using Coalesce.Test.Data.Models;

namespace Coalesce.Test.Data;

[Coalesce]
public class AppDbContext : DbContext
{
    public DbSet<Widget> Widgets => Set<Widget>();

    public AppDbContext() { }

    public AppDbContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Remove cascading deletes.
        foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
        {
            relationship.DeleteBehavior = DeleteBehavior.Restrict;
        }
    }
}
