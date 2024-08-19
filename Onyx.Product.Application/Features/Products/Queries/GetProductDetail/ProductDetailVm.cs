namespace Onyx.Product.Application.Features.Products.Queries.GetProductDetail
{
    public class ProductDetailVm
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public Guid ColourId { get; set; }
        public ColourDto Colour { get; set; } = default;

    }
}
