﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrdersManager.Domain.Models;
using OrdersManager.DTO.Order;
using OrdersManager.Interfaces;
using OrdersManager.Interfaces.Services;

namespace OrdersManager.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersService _ordersService;

        public OrdersController(IOrdersService ordersService)
        {
            _ordersService = ordersService;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            var orders = _ordersService.GetAll();

            return Ok(orders);
        }

        [HttpGet("{id}", Name = "OrderById")]
        public IActionResult Get(Guid id)
        {
            var order = _ordersService.GetById(id);

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

            var orderEntity = _ordersService.Create(order);

            return CreatedAtRoute("OrderById", new { id = orderEntity.Id }, orderEntity);
        }

        [HttpPut]
        public IActionResult Update([FromBody] OrderForUpdateDto order)
        {
            if (order == null)
            {
                return BadRequest("Object sent from client is null");
            }

            var isEntityFound = _ordersService.Update(order);

            if (!isEntityFound)
            {
                return NotFound($"Entity with id: {order.Id} doesn't exist in datebase");
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var isEntityFound = _ordersService.Delete(id);

            if (!isEntityFound)
            {
                return NotFound($"Entity with id: {id} doesn't exist in the database.");
            }

            return NoContent();
        }
    }
}
