using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using lab1.models;
namespace lab1.data;
public class ViewContext : DbContext
{   
    // Variables
    public virtual DbSet<NavItem> NavLeftDashboardAdmin{ get; set; }
    
    // Constructor
    public ViewContext(DbContextOptions<ViewContext> options) : base(options) { }

    // Override
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<NavItem>().ToTable(nameof(NavItem));
        // Auto Generated Primary Key
        modelBuilder.Entity<NavItem>().HasKey(c => c.ID);
        // Auto Increment Primary Key
        modelBuilder.Entity<NavItem>()
            .Property(c => c.ID)
            .ValueGeneratedOnAdd();
    }
}
