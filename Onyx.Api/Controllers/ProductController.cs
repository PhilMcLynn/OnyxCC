using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Onyx.Product.Application.Features.Colours;
using Onyx.Product.Application.Features.Products;
using Onyx.Product.Application.Features.Products.Commands;
using Onyx.Product.Application.Features.Products.Queries.GetProductDetail;
using Onyx.Product.Application.Features.Products.Queries.GetProductList;

namespace Onyx.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    #if !INTEGRATIONTEST
        [Authorize]
    #endif
    
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("allColours", Name = "GetAllColors")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<ColourListVm>>> GetAllColours()
        {
            var dtos = await _mediator.Send(new GetColourListQuery());
            return Ok(dtos);
        }

        [HttpGet(Name = "GetAllProducts")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<ProductListVm>>> GetAllProducts([FromQuery] ProductFilterDto filterDto)
        {
            var getProductsListQuery = new GetProductsListQuery() { ColourId = filterDto.ColourId };
            var dtos = await _mediator.Send(getProductsListQuery);
            return Ok(dtos);
        }

        [HttpGet("{id}", Name = "GetProductById")]
        public async Task<ActionResult<ProductDetailVm>> GetProductById(Guid id)
        {
            var getProductDetailQuery = new GetProductDetailQuery() { Id = id };
            return Ok(await _mediator.Send(getProductDetailQuery));
        }

        [HttpPost("addproduct", Name = "AddProduct")]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateProductCommand createProductCommand)
        {
            var id = await _mediator.Send(createProductCommand);
            return Ok(id);
        }

    }
}
