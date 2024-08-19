using Microsoft.EntityFrameworkCore;
using Onyx.Product.Application.Contracts.Persistence;
using DOMAIN = Onyx.Product.Domain.Entities;

namespace Onyx.Product.Persistence.Repositories
{
    public class ProductRepository :BaseRepository<DOMAIN.Product>, IProductRepository
    {
        public ProductRepository(ProductDbContext dbContext) : base(dbContext)
        {
        }
        public Task<bool> IsNewProductNameFoundInDb(string name)
        {
            var matches = _dbContext.Products.Any(e => e.Name.Equals(name));
            return Task.FromResult(matches);
        }
        public async Task<List<DOMAIN.Product>> GetWithFilterIdAsync(Guid? Id)
        {
            var matches = await _dbContext.Products.Where(e => e.ColourId.Equals(Id)).ToListAsync<DOMAIN.Product>();
            return matches;
        }

    }
}
