using AutoMapper;
using MediatR;
using Onyx.Product.Application.Contracts.Persistence;
using DOMAIN = Onyx.Product.Domain.Entities;

namespace Onyx.Product.Application.Features.Products.Commands
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        public DeleteProductCommandHandler(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task Handle(DeleteProductCommand request, CancellationToken cancellation)
        {
            var productToDelete = await _productRepository.GetByIdAsync(request.Id);

            await _productRepository.DeleteAsync(productToDelete);
        }
    }
}
