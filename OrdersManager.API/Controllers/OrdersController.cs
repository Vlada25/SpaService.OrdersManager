using MassTransit;
using Microsoft.AspNetCore.Mvc;
using OrdersManager.DTO.Order;
using OrdersManager.Interfaces.Services;

namespace OrdersManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersService _ordersService;

        public OrdersController(IOrdersService ordersService)
        {
            _ordersService = ordersService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var orders = await _ordersService.GetAll();

            return Ok(orders);
        }

        [HttpGet("{id}", Name = "OrderById")]
        public async Task<IActionResult> Get(Guid id)
        {
            var order = await _ordersService.GetById(id);

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
        public async Task<IActionResult> Create([FromBody] OrderForCreationDto order)
        {
            if (order == null)
            {
                return BadRequest("Object sent from client is null");
            }

            var orderEntity = await _ordersService.Create(order);

            return CreatedAtRoute("OrderById", new { id = orderEntity.Id }, orderEntity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] OrderForUpdateDto order)
        {
            if (order == null)
            {
                return BadRequest("Object sent from client is null");
            }

            var isEntityFound = await _ordersService.Update(id, order);

            if (!isEntityFound)
            {
                return NotFound($"Entity with id: {id} doesn't exist in datebase");
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var isEntityFound = await _ordersService.Delete(id);

            if (!isEntityFound)
            {
                return NotFound($"Entity with id: {id} doesn't exist in the database.");
            }

            return NoContent();
        }
    }
}
