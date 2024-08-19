using Onyx.Product.Application.Contracts.Persistence;
using Onyx.Product.Domain.Entities;

namespace Onyx.Product.Persistence.Repositories
{
    public class ColourRepository : BaseRepository<Colour>, IColourRepository
    {
        public ColourRepository(ProductDbContext dbContext) : base(dbContext)
        {
        }
    }
}