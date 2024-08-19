using DOMAIN = Onyx.Product.Domain.Entities;    // Change so that "product" is not in the namespace

namespace Onyx.Product.Application.Contracts.Persistence
{
    public interface IProductRepository : IAsyncRepository<DOMAIN.Product>
    {
        Task<bool> IsNewProductNameFoundInDb(string name);
        Task<List<DOMAIN.Product>> GetWithFilterIdAsync(Guid? Id);
    }
}
