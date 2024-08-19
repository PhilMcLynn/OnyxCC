using MediatR;

namespace Onyx.Product.Application.Features.Products.Queries.GetProductList
{
    public class GetProductsListQuery : IRequest<List<ProductListVm>>
    {
        public Guid? ColourId { get; set; }
    }
}
