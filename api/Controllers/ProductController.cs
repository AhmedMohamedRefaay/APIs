using ApiContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain;
using Application.Features.Products.Queries.GetAllQuery;
using MediatR;
using Application.Features.Products.Queries.GetProductById;
using Application.Features.Products.Commands.CreateProduct;
using Application.Features.Products.Commands.UpdateProduct;
using Application.Features.Categories.Commands.DeleteProduct;

namespace api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
         
        public ProductController(IMediator mediator )
        {
            _mediator = mediator;
        }


     [Authorize]
        public async Task<IActionResult> GetAllProduct([FromQuery] GetAllProductsQuery query)
        {
            try
            {

                return Ok(await _mediator.Send(query));

            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductyById(long id)
        {
            try
            {

                return Ok(await _mediator.Send(new GetProductByIdQuery() { Id = id }));


            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }

        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] Product product )
        {
            try
            {

                return Ok(await _mediator.Send(new CreateProductCaommand
               (product.Name,
               product.Discount,
               product.Discription))); ;


            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromBody] Product product)
        {
            try
            {

                return Ok(await _mediator.Send(new UpdateProductCommand
               (
              product.Id,
               product.Name,
               product.Discription,
               product.Discount
            ))); 


            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(long id)
        {

            return Ok(await _mediator.Send(new DeleteProductCommand() { Id = id }));

        }

    }
}
