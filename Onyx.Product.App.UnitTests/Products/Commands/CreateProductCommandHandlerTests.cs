using AutoMapper;
using Moq;
using Onyx.Product.App.UnitTests.Mocks;
using Onyx.Product.Application.Contracts.Persistence;
using Onyx.Product.Application.Features.Products.Commands;
using Onyx.Product.Application.Features.Profiles;
using Onyx.Product.Domain.Entities;
using Shouldly;
using Onyx.Product.Application.Exceptions;
using System.Linq;

namespace Onyx.Product.App.UnitTests.Products.Commands
{
    public class CreateProductCommandHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IProductRepository> _mockProductRepository;
        private readonly Mock<IAsyncRepository<Colour>> _mockColourRepository;
        public CreateProductCommandHandlerTests()
        {
            _mockProductRepository = RepositoryMocks.GetProductRepository();
            _mockColourRepository = RepositoryMocks.GetColourRepository();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            _mapper = configurationProvider.CreateMapper();
        }
        [Fact]
        public async Task CreateProductCommandHandlerPassTest()
        {
            var redColour = Guid.Parse("bea9fffd-6c23-44f5-b377-ed7aa6d08c7a");
            var handler = new CreateProductCommandHandler(_mapper, 
                                                            _mockProductRepository.Object, 
                                                            _mockColourRepository.Object);
            var result = await handler.Handle(new CreateProductCommand()
                                                {
                                                    Name = "E Bike",
                                                    Description = "Trail cycle",
                                                    Price = 299.99m,
                                                    ColourId = redColour
                                                }, CancellationToken.None);

            var expectedGuid = Guid.Parse("08ce4b3e-dde0-4563-86a7-321cd32b30f6");
            result.ShouldBeOfType<Guid>();

            result.ShouldBe(expectedGuid);
        }
        [Fact]
        public async Task CreateProductCommandHandlerValidatorFailTest()
        {
            bool validationErrorCaught = false;
            var redColour = Guid.Parse("bea9fffd-6c23-44f5-b377-ed7aa6d08c7a");
            var handler = new CreateProductCommandHandler(_mapper,
                                                            _mockProductRepository.Object,
                                                            _mockColourRepository.Object);
            try
            {
                var result = await handler.Handle(new CreateProductCommand()
                {
                    Name = "123456789012345678901234567890123456789012345678901",
                    Description = "12345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901",
                    Price = 0,
                    ColourId = Guid.NewGuid()
                }, CancellationToken.None);
            }
            catch (ValidationException ex) 
            {
                validationErrorCaught = true;
                Console.WriteLine(ex.Message);
                ex.ValidationErrors
                    .Count.ShouldBe(5);
                ex.ValidationErrors.ShouldContain<string>("Price is required.");
                ex.ValidationErrors.ShouldContain<string>(@"'Price' must be greater than '0'.");
                ex.ValidationErrors.ShouldContain<string>("Name must not exceed 50 characters.");
                ex.ValidationErrors.ShouldContain<string>("Description must not exceed 100 characters.");
                ex.ValidationErrors.ShouldContain<string>("Unknown colour provided.");
            }
            validationErrorCaught.ShouldBeTrue();
        }
        [Fact]
        public async Task CreateProductCommandHandlerValidatorFailNameNotUniqueTest()
        {
            _mockProductRepository.Setup(repo => repo.IsNewProductNameFoundInDb(It.IsAny<string>())).ReturnsAsync(true);
            bool validationErrorCaught = false;
            var redColour = Guid.Parse("bea9fffd-6c23-44f5-b377-ed7aa6d08c7a");
            var handler = new CreateProductCommandHandler(_mapper,
                                                            _mockProductRepository.Object,
                                                            _mockColourRepository.Object);
            try
            {
                var result = await handler.Handle(new CreateProductCommand()
                {
                    Name = "Mountain Bike",
                    Description = "Trail cycle",
                    Price = 299.99m,
                    ColourId = redColour
                }, CancellationToken.None);
            }
            catch (ValidationException ex)
            {
                validationErrorCaught = true;
                Console.WriteLine(ex.Message);
                ex.ValidationErrors
                    .Count.ShouldBe(1);
                ex.ValidationErrors.ShouldContain<string>("A product with the same name already exists.");
            }
            validationErrorCaught.ShouldBeTrue();
        }

    }
}
