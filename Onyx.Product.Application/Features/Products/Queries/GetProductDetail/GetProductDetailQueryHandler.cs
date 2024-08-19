using AutoMapper;
using MediatR;
using Onyx.Product.Application.Contracts.Persistence;
using Onyx.Product.Domain.Entities;
using DOMAIN = Onyx.Product.Domain.Entities;

namespace Onyx.Product.Application.Features.Products.Queries.GetProductDetail
{
    public class GetProductDetailQueryHandler : IRequestHandler<GetProductDetailQuery, ProductDetailVm>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        private readonly IAsyncRepository<Colour> _colourRepository;
        public GetProductDetailQueryHandler(IMapper mapper,
            IProductRepository productRepository,
            IAsyncRepository<Colour> colourRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
            _colourRepository = colourRepository;
        }
        public async Task<ProductDetailVm> Handle(GetProductDetailQuery request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id);
            var productDetailDto = _mapper.Map<ProductDetailVm>(product);

            var colour = await _colourRepository.GetByIdAsync(product.ColourId);

            productDetailDto.Colour = _mapper.Map<ColourDto>(colour);

            return productDetailDto;
        }

    }
}
