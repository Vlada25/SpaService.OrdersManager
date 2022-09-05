using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrdersManager.Domain.Models;
using OrdersManager.DTO.Schedule;
using OrdersManager.Interfaces;
using OrdersManager.Interfaces.Services;

namespace OrdersManager.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SchedulesController : ControllerBase
    {
        private readonly ISchedulesService _schedulesService;

        public SchedulesController(ISchedulesService schedulesService)
        {
            _schedulesService = schedulesService;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            var schedules = _schedulesService.GetAll();

            return Ok(schedules);
        }

        [HttpGet("{id}", Name = "ScheduleById")]
        public IActionResult Get(Guid id)
        {
            var schedule = _schedulesService.GetById(id);

            if (schedule == null)
            {
                return NotFound($"Entity with id: {id} doesn't exist in datebase");
            }
            else
            {
                return Ok(schedule);
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] ScheduleForCreationDto schedule)
        {
            if (schedule == null)
            {
                return BadRequest("Object sent from client is null");
            }

            var scheduleEntity = _schedulesService.Create(schedule);

            return CreatedAtRoute("ScheduleById", new { id = scheduleEntity.Id }, scheduleEntity);
        }

        [HttpPut]
        public IActionResult Update([FromBody] ScheduleForUpdateDto schedule)
        {
            if (schedule == null)
            {
                return BadRequest("Object sent from client is null");
            }

            var isEntityFound = _schedulesService.Update(schedule);

            if (!isEntityFound)
            {
                return NotFound($"Entity with id: {schedule.Id} doesn't exist in datebase");
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var isEntityFound = _schedulesService.Delete(id);

            if (!isEntityFound)
            {
                return NotFound($"Entity with id: {id} doesn't exist in the database.");
            }

            return NoContent();
        }
    }
}
