using EmptyFiles;
using Moq;
using Onyx.Product.Application.Contracts.Persistence;
using Onyx.Product.Domain.Entities;
using DOMAIN = Onyx.Product.Domain.Entities;

namespace Onyx.Product.App.UnitTests.Mocks
{
    public class RepositoryMocks
    {
        public static Mock<IProductRepository> GetProductRepository()
        {
            var redColour = Guid.Parse("bea9fffd-6c23-44f5-b377-ed7aa6d08c7a");
            var amberColour = Guid.Parse("e77e6081-e479-48a6-8df7-4b6035b5a912");

            var products = new List<DOMAIN.Product>
            {
                new DOMAIN.Product
                {
                    ProductId = Guid.Parse("08ce4b3e-dde0-4563-86a7-321cd32b30f6"),
                    Name = "Mountain Bike",
                    Description = "Trail cycle",
                    Amount = 299.99m,
                    ColourId = redColour,
                    CreatedBy = "Joe Bloggs"
                },
                new DOMAIN.Product
                {
                    ProductId = Guid.Parse("a25ee03f-a1b0-4746-affb-db75e8f10729"),
                    Name = "Race Bike",
                    Description = "Racing cycle",
                    Amount = 499.99m,
                    ColourId = amberColour,
                    CreatedBy = "John Doe"
                }
            };
            var mockProductRepository = new Mock<IProductRepository>();
            mockProductRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(products);
            mockProductRepository.Setup(repo => repo.GetWithFilterIdAsync(It.IsAny<Guid>())).ReturnsAsync(products);
            mockProductRepository.Setup(repo => repo.AddAsync(It.IsAny<DOMAIN.Product>()))
                .ReturnsAsync(products[0]);
            return mockProductRepository;
        }

        public static Mock<IAsyncRepository<Colour>> GetColourRepository()
        {
            var redColour = Guid.Parse("bea9fffd-6c23-44f5-b377-ed7aa6d08c7a");
            var amberColour = Guid.Parse("e77e6081-e479-48a6-8df7-4b6035b5a912");

            var mockColourRepository = new Mock<IAsyncRepository<Colour>>();
            mockColourRepository.Setup(repo => repo.GetByIdAsync(It.IsAny<Guid>()))
                .ReturnsAsync(new Colour { ColourId = redColour });
            var colours = new List<Colour>
            {
                new Colour { ColourId = redColour, Name = "Red" },
                new Colour { ColourId = amberColour, Name = "Amber" }
            };
            mockColourRepository.Setup(repo => repo.GetAllAsync())
                .ReturnsAsync(colours);

            return mockColourRepository;
        }
    }
}
