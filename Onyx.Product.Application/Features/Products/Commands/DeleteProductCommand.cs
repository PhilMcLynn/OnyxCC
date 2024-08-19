using MediatR;

namespace Onyx.Product.Application.Features.Products.Commands
{
    public class DeleteProductCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
