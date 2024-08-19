using Onyx.Product.App.IntegrationTests.Base;
using Onyx.Product.Application.Features.Colours;
using Onyx.Product.Application.Features.Products.Queries.GetProductList;
using Shouldly;
using System.Text.Json;

namespace Onyx.Product.App.IntegrationTests.Controllers
{
    public class ProductControllerTests : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly CustomWebApplicationFactory<Program> _factory;
        public ProductControllerTests(CustomWebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }
        [Fact]
        public async Task ColoursReturnsSuccessResult()
        {
            var client = _factory.GetAnonymousClient();
            
            var response = await client.GetAsync("/api/product/allColours");

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            var result = JsonSerializer.Deserialize<List<ColourListVm>>(responseString);

            result.ShouldBeOfType<List<ColourListVm>>();
            result.ShouldNotBeEmpty();
            result.Count.ShouldBe(3);
        }
        [Fact]
        public async Task ProductAllListReturnsSuccessResult()
        {
            var client = _factory.GetAnonymousClient();

            var response = await client.GetAsync("/api/product");

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            var result = JsonSerializer.Deserialize<List<ProductListVm>>(responseString);

            result.ShouldBeOfType<List<ProductListVm>>();
            result.ShouldNotBeEmpty();
            result.Count.ShouldBe(2);
        }
    }
}