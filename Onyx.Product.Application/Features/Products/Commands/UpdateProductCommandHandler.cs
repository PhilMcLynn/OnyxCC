using AutoMapper;
using MediatR;
using Onyx.Product.Application.Contracts.Persistence;
using Onyx.Product.Application.Exceptions;
using DOMAIN = Onyx.Product.Domain.Entities;

namespace Onyx.Product.Application.Features.Products.Commands
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        public UpdateProductCommandHandler(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task Handle(UpdateProductCommand request, CancellationToken cancellation)
        {
            var productToUpdate = await _productRepository.GetByIdAsync(request.ProductId);
            if (productToUpdate == null)
            {
                throw new NotFoundException(nameof(DOMAIN.Product),request.ProductId);
            }
            // include the validation here

            _mapper.Map(request, productToUpdate, typeof(UpdateProductCommand), typeof(DOMAIN.Product))                ;

            await _productRepository.UpdateAsync(productToUpdate);
        }
    }
}
