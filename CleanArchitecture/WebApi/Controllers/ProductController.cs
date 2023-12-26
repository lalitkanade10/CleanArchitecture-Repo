using Application.Feature.Product.Command;
using Application.Feature.Product.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet("")]
        public async Task<IActionResult> GetProducts(CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetAllProductQueries(), cancellationToken);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductsByID(int id,CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetProductByIdQueries{ ID=id}, cancellationToken);
            return Ok(result);
        }

        [HttpPost("CreateProduct")]
        public async Task<IActionResult> CreateProduct(CreateProductCommand createProduct, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(createProduct, cancellationToken);
            return Ok(result);
        }

        [HttpPut("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct(UpdateProductCommand UpdateProduct, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(UpdateProduct, cancellationToken);
            return Ok(result);
        }

        [HttpDelete("DeleteProduct/{id}")]
        public async Task<IActionResult> DeleteProduct(int id,CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new DeleteProductCommand { ID=id}, cancellationToken);
            return Ok(result);
        }
    }
}
