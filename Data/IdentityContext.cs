
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
//
using lab1.models;

namespace lab1.data;

public class IdentityContext : IdentityDbContext<IdentityUserCustom>
{
    public IdentityContext(
        DbContextOptions<IdentityContext> options
    ) : base(options) { 
        
    }
}