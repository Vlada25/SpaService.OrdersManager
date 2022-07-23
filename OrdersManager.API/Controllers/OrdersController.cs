using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrdersManager.Domain.Models;
using OrdersManager.DTO.Order;
using OrdersManager.Interfaces;

namespace OrdersManager.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public OrdersController(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repository = repositoryManager;
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            var orders = _repository.OrdersRepository.GetAll(trackChanges: false);

            return Ok(orders);
        }

        [HttpGet("{id}", Name = "OrderById")]
        public IActionResult Get(Guid id)
        {
            var order = _repository.OrdersRepository.GetById(id, trackChanges: false);

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
        public IActionResult Create([FromBody] OrderForCreationDto order)
        {
            if (order == null)
            {
                return BadRequest("Object sent from client is null");
            }

            var orderEntity = _mapper.Map<Order>(order);

            _repository.OrdersRepository.Create(orderEntity);
            _repository.Save();

            return CreatedAtRoute("OrderById", new { id = orderEntity.Id }, orderEntity);
        }

        [HttpPut]
        public IActionResult Update([FromBody] OrderForUpdateDto order)
        {
            if (order == null)
            {
                return BadRequest("Object sent from client is null");
            }

            var orderEntity = _repository.OrdersRepository.GetById(order.Id, trackChanges: true);

            if (orderEntity == null)
            {
                return NotFound($"Entity with id: {order.Id} doesn't exist in datebase");
            }

            _mapper.Map(order, orderEntity);
            _repository.Save();

            return Ok("Entity was updated");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var order = _repository.OrdersRepository.GetById(id, trackChanges: false);

            if (order == null)
            {
                return NotFound($"Entity with id: {id} doesn't exist in the database.");
            }

            _repository.OrdersRepository.Delete(order);
            _repository.Save();

            return Ok("Entity was deleted");
        }
    }
}
