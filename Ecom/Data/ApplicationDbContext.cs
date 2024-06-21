using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Ecom.Models;

namespace Ecom.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Ecom.Models.Product> Product { get; set; } = default!;
        public DbSet<Ecom.Models.Artisan> Artisan { get; set; } = default!;
    }
}
