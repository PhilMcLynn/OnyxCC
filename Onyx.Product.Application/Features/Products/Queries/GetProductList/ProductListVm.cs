using Onyx.Product.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onyx.Product.Application.Features.Products.Queries.GetProductList
{
    public class ProductListVm
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }

        public decimal Price { get; set; }
        public Guid ColourId { get; set; }
        //public Colour Colour { get; set; }
    }
}
