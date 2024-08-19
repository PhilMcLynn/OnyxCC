using MediatR;

namespace Onyx.Product.Application.Features.Products.Commands
{
    public class UpdateProductCommand : IRequest
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public Guid ColourId { get; set; }
    }
}
