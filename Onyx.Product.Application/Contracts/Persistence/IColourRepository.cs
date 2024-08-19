using Onyx.Product.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onyx.Product.Application.Contracts.Persistence
{
    public interface IColourRepository : IAsyncRepository<Colour>
    {
    }
}
