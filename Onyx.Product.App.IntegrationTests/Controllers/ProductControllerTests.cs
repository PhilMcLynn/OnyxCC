using Onyx.Product.App.IntegrationTests.Base;
using Onyx.Product.Application.Features.Colours;
using Onyx.Product.Application.Features.Products.Queries.GetProductList;
using Shouldly;
using System.Text;
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
        }
        [Fact]
        public async Task ProductCreateReturnsSuccessResult()
        {
            var client = _factory.GetAnonymousClient();

            using StringContent jsonContent = new(
                JsonSerializer.Serialize(new
                {
                    Name = "Commuter bicycle",
                    Description = "Commuter bicycle long description",
                    Price = 959.99, 
                    ColourId = "e77e6081-e479-48a6-8df7-4b6035b5a912"
                }), Encoding.UTF8, "application/json");

            using HttpResponseMessage response = await client.PostAsync("api/product/addproduct", jsonContent);

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            var result = JsonSerializer.Deserialize<Guid>(responseString);

            result.ShouldBeOfType<Guid>();
        }
    }
}