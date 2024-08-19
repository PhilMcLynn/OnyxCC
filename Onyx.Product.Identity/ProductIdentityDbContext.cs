using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Onyx.Product.Identity.Models;

namespace Onyx.Product.Identity
{
    public class ProductIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public ProductIdentityDbContext()
        {
        }

        public ProductIdentityDbContext(DbContextOptions<ProductIdentityDbContext> options) 
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder
            .LogTo(Console.WriteLine)
            .EnableSensitiveDataLogging();
    }
}
