
using FluentValidation;
using Onyx.Product.Application.Contracts.Persistence;
using Onyx.Product.Domain.Entities;

namespace Onyx.Product.Application.Features.Products.Commands
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        private readonly IProductRepository _productRepository;
        private readonly IAsyncRepository<Colour> _colourRepository;
        public CreateProductCommandValidator(IProductRepository productRepository, IAsyncRepository<Colour> colourRepository)
        {
            _productRepository = productRepository;
            _colourRepository = colourRepository;

            RuleFor( p  => p.Name )
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor( p => p.Description )
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 100 characters.");

            RuleFor(p => p.Price)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .GreaterThan(0);

            RuleFor(e => e)
                .MustAsync(ProductNameUnique)
                .WithMessage("A product with the same name already exists.");

            RuleFor(e => e)
                .MustAsync(ColourIsKnown)
                .WithMessage("Unknown colour provided.");
        }

        private async Task<bool> ColourIsKnown(CreateProductCommand e, CancellationToken cancellation)
        {
            return (await _colourRepository.GetAllAsync()).Any(row => row.ColourId == e.ColourId);
        }
        private async Task<bool> ProductNameUnique(CreateProductCommand e, CancellationToken cancellation)
        {
            return !await _productRepository.IsNewProductNameFoundInDb(e.Name);
        }
    }
}
