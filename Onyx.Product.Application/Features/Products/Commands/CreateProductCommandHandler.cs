using AutoMapper;
using MediatR;
using Onyx.Product.Application.Contracts.Persistence;
using Onyx.Product.Domain.Entities;
using DOMAIN = Onyx.Product.Domain.Entities;

namespace Onyx.Product.Application.Features.Products.Commands
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand,Guid>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        private readonly IAsyncRepository<Colour> _colourRepository;
        public CreateProductCommandHandler(IMapper mapper, IProductRepository productRepository, 
            IAsyncRepository<Colour> colourRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
            _colourRepository = colourRepository;
        }

        public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellation)
        {
            var product = _mapper.Map<DOMAIN.Product>(request);

            var validator = new CreateProductCommandValidator(_productRepository, _colourRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new Exceptions.ValidationException(validationResult);

            product = await _productRepository.AddAsync(product);
            return product.ProductId;
        }
    }
}
