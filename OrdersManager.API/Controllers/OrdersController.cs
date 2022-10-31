using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrdersManager.CQRS.Commands.Orders;
using OrdersManager.CQRS.Queries.Orders;

namespace OrdersManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #region CRUD

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var orders = await _mediator.Send(new GetAllOrdersQuery());

            return Ok(orders);
        }

        [HttpGet("{id}", Name = "OrderById")]
        public async Task<IActionResult> Get(Guid id)
        {
            var order = await _mediator.Send(new GetOrderByIdQuery
            {
                Id = id
            });

            if (order == null)
            {
                return NotFound($"Entity with id: {id} doesn't exist in datebase");
            }
            else
            {
                return Ok(order);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateOrderCommand order)
        {
            if (order == null)
            {
                return BadRequest("Object sent from client is null");
            }

            var orderEntity = await _mediator.Send(order);

            return CreatedAtRoute("OrderById", new { id = orderEntity.Id }, orderEntity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateOrderCommand order)
        {
            if (order == null)
            {
                return BadRequest("Object sent from client is null");
            }

            var isEntityFound = await _mediator.Send(order);

            if (!isEntityFound)
            {
                return NotFound($"Entity with id: {id} doesn't exist in datebase");
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var isEntityFound = await _mediator.Send(new DeleteOrderCommand
            {
                Id = id
            });

            if (!isEntityFound)
            {
                return NotFound($"Entity with id: {id} doesn't exist in the database.");
            }

            return NoContent();
        }

        #endregion

        [HttpGet("Clients/{clientId}")]
        public async Task<IActionResult> GetByClientId(Guid clientId)
        {
            var orders = await _mediator.Send(new GetOrdersByClientIdQuery
            {
                ClientId = clientId
            });

            return Ok(orders);
        }

        [HttpGet("Schedules/{scheduleId}")]
        public async Task<IActionResult> GetByScheduleId(Guid scheduleId)
        {
            var order = await _mediator.Send(new GetOrderByScheduleIdQuery
            {
                ScheduleId = scheduleId
            });

            return Ok(order);
        }
    }
}
