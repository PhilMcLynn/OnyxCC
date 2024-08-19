using MediatR;
using Onyx.Product.Application.Features.Products.Queries.GetProductDetail;

namespace Onyx.Product.Application.Features.Products
{
    public class GetProductDetailQuery : IRequest<ProductDetailVm>
    {
        public Guid Id { get; set; }
    }
}
