using MediatR;

namespace Onyx.Product.Application.Features.Products.Commands
{
    public class CreateProductCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public Guid ColourId { get; set; }

        public override string ToString()
        {
            return $"Product name: {Name}; Price: {Price}; Description: {Description}";
        }
    }
}
