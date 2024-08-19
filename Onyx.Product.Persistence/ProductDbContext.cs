using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Onyx.Product.Application.Contracts;
using Onyx.Product.Domain.Common;
using Onyx.Product.Domain.Entities;
using DOMAIN = Onyx.Product.Domain.Entities;

namespace Onyx.Product.Persistence
{
    public class ProductDbContext: DbContext
    {
        private readonly IUserService? _userService;
        public ProductDbContext(DbContextOptions<ProductDbContext> options)
            :base(options)
        {
        }
        public ProductDbContext(IUserService userService, DbContextOptions<ProductDbContext> options)
            : base(options)
        {
            _userService = userService;
        }

        public DbSet<DOMAIN.Product> Products { get; set; }
        public DbSet<Colour> Colours { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductDbContext).Assembly);
            // seed data, added through migrations
            var redColour = Guid.Parse("bea9fffd-6c23-44f5-b377-ed7aa6d08c7a");
            var amberColour = Guid.Parse("e77e6081-e479-48a6-8df7-4b6035b5a912");
            var greenColour = Guid.Parse("d896da4c-cb30-4d74-9850-9c963fc5088e");

            modelBuilder.Entity<Colour>().HasData(new Colour
            {
                ColourId = redColour,
                Name = "Red"
            });
            modelBuilder.Entity<Colour>().HasData(new Colour
            {
                ColourId = amberColour,
                Name = "Amber"
            });
            modelBuilder.Entity<Colour>().HasData(new Colour
            {
                ColourId = greenColour,
                Name = "Green"
            });

            modelBuilder.Entity<DOMAIN.Product>().HasData(new DOMAIN.Product
            {
                ProductId = Guid.Parse("08ce4b3e-dde0-4563-86a7-321cd32b30f6"),
                Name = "Mountain Bike",
                Description = "Trail cycle",
                Amount = 299.99m,
                ColourId = redColour,
                CreatedBy = "Joe Bloggs"
            });
            modelBuilder.Entity<DOMAIN.Product>().HasData(new DOMAIN.Product
            {
                ProductId = Guid.Parse("a25ee03f-a1b0-4746-affb-db75e8f10729"),
                Name = "Race Bike",
                Description = "Racing cycle",
                Amount = 499.99m,
                ColourId = amberColour,
                CreatedBy = "John Doe"
            });

            //base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync( CancellationToken cancellationToken = new CancellationToken())
        {
            foreach( var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        entry.Entity.CreatedBy = _userService.UserId;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        entry.Entity.LastModifiedBy = _userService.UserId;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
