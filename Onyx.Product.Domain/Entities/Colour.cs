using Onyx.Product.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onyx.Product.Domain.Entities
{
    public class Colour : AuditableEntity
    {
        public Guid ColourId {get; set;}
        public string Name { get; set;}

    }
}
