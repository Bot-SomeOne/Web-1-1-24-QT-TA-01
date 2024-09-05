
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
//
using lab1.models;

namespace lab1.data;

public class IdentityContext : IdentityDbContext<IdentityUserCustom>
{
    public IdentityContext(
        DbContextOptions<IdentityContext> options
    ) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {

        base.OnModelCreating(builder);
        // Bỏ tiền tố AspNet của các bảng: mặc định
        foreach (var entityType in builder.Model.GetEntityTypes())
        {
            var tableName = entityType.GetTableName();
            if (tableName.StartsWith("AspNet"))
            {
                entityType.SetTableName(tableName.Substring(6));
            }
        }
    }
}