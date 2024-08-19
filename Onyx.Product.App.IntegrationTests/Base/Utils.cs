using DOMAIN=Onyx.Product.Domain.Entities;
using Onyx.Product.Persistence;

namespace Onyx.Product.App.IntegrationTests.Base
{
    public class Utils
    {
        public static void InitDbForTests(ProductDbContext productDbContext)
        {


            productDbContext.Products.RemoveRange(productDbContext.Products);
            productDbContext.Colours.RemoveRange(productDbContext.Colours);
            productDbContext.SaveChanges();

            var redColour = Guid.Parse("bea9fffd-6c23-44f5-b377-ed7aa6d08c7a");
            var amberColour = Guid.Parse("e77e6081-e479-48a6-8df7-4b6035b5a912");

            productDbContext.Colours.Add(new DOMAIN.Colour() { ColourId = redColour, Name = "Red"});
            productDbContext.Colours.Add(new DOMAIN.Colour() { ColourId = amberColour, Name = "Amber"});
            productDbContext.Products.Add(new DOMAIN.Product()
            {
                ProductId = Guid.Parse("08ce4b3e-dde0-4563-86a7-321cd32b30f6"),
                Name = "Mountain Bike",
                Description = "Trail cycle",
                Amount = 299.99m,
                ColourId = redColour,
                CreatedBy = "Joe Bloggs"
            });
            productDbContext.Products.Add(new DOMAIN.Product()
            {
                ProductId = Guid.Parse("a25ee03f-a1b0-4746-affb-db75e8f10729"),
                Name = "Race Bike",
                Description = "Racing cycle",
                Amount = 499.99m,
                ColourId = amberColour,
                CreatedBy = "John Doe"
            });
            productDbContext.SaveChanges();
        }
    }
}
