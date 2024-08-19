using AutoMapper;
using MediatR;
using Onyx.Product.Application.Contracts.Persistence;

namespace Onyx.Product.Application.Features.Products.Queries.GetProductList
{
    public class GetProductListQueryHandler : IRequestHandler<GetProductsListQuery, List<ProductListVm>>
    {
        private readonly  IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductListQueryHandler(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }
        public async Task<List<ProductListVm>> Handle(GetProductsListQuery request, CancellationToken cancellationToken)
        {
            if (request.ColourId == null)
            {
                var allProducts = await _productRepository.GetAllAsync();
                return _mapper.Map<List<ProductListVm>>(allProducts);
            }
            else
            {
                var allProducts = await _productRepository.GetWithFilterIdAsync(request.ColourId);
                return _mapper.Map<List<ProductListVm>>(allProducts);
            }
        }
    }
}
