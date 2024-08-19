using AutoMapper;
using Moq;
using Onyx.Product.App.UnitTests.Mocks;
using Onyx.Product.Application.Contracts.Persistence;
using Onyx.Product.Application.Features.Products.Queries.GetProductList;
using Onyx.Product.Application.Features.Profiles;
using Onyx.Product.Domain.Entities;
using Shouldly;

namespace Onyx.Product.App.UnitTests.Products.Queries
{
    public class GetProductListQueryHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IProductRepository> _mockProductRepository;
        private readonly Mock<IAsyncRepository<Colour>> _mockColourRepository;
        public GetProductListQueryHandlerTests()
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
        public async Task GetProductsListAllTest()
        {
            var handler = new GetProductListQueryHandler(_mapper, _mockProductRepository.Object);

            var result = await handler.Handle( new GetProductsListQuery() { ColourId = null}, 
                                               CancellationToken.None);

            result.ShouldBeOfType<List<ProductListVm>>();
                  
            result.Count.ShouldBe(2);
        }
        [Fact]
        public async Task GetProductsListWithFilterTest()
        {
            var redColour = Guid.Parse("bea9fffd-6c23-44f5-b377-ed7aa6d08c7a");
            var handler = new GetProductListQueryHandler(_mapper, _mockProductRepository.Object);

            var result = await handler.Handle(new GetProductsListQuery() { ColourId = redColour },
                                                CancellationToken.None);

            result.ShouldBeOfType<List<ProductListVm>>();

            result.Count.ShouldBe(2);
        }
    }
}
