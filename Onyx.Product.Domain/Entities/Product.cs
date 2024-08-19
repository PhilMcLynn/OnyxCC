using Onyx.Product.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onyx.Product.Domain.Entities
{
    public class Product : AuditableEntity
    {
        public Guid ProductId { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public decimal Amount { get; set; }
        
        public Guid ColourId { get; set; }
        public Colour Colour { get; set; } = default!;

    }
}
