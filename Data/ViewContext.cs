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
    }
}
