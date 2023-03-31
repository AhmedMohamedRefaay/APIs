using Application.Features.Categories.Commands.DeleteProduct;
using Application.Features.Orders.Commands.CreateOrder;
using Application.Features.Orders.Commands.DeleteOrder;
using Application.Features.Orders.Commands.UpdateOrder;
using Application.Features.Orders.Queries.GetAllOrders;
using Application.Features.Orders.Queries.GetOrderDetails;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
       

        private readonly IMediator mediator;

        public OrderController(IMediator mediator)
        {
            this.mediator = mediator;
           
        }

        // URL - http://localhost:5011/api/Order/ type GET
        [HttpGet]
        public async Task<IActionResult> GetAllOrders([FromQuery] GetAllOrdersQuery query)
        {
            return Ok(await mediator.Send(query ));

        }

        // URL -  http://localhost:5011/api/Order/{id} type GET
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderDetails(int id)
        {
            // command.Id=id;
            return Ok(await mediator.Send(new GetOrderDetailsQuery() { Id=id }));
        }
        // URL - http://localhost:5118/api/Order/ type Post
        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderCommand query)
        {
            try
            {

                return Ok(await mediator.Send(new CreateOrderCommand
               (query.products))); ;


            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        // URL - http://localhost:5118/api/Order/{id} type Put (Update)
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateOrder(int id,UpdateOrderCommand command)
        {
            command.Id = id;
            return Ok(await mediator.Send(command));

        }
        // URL - http://localhost:5118/api/Order/{id} type Delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id, [FromQuery] DeleteOrderCommand command)
        {
            command.Id = id;
            return Ok(await mediator.Send(command));
        }
    }
       
    }
