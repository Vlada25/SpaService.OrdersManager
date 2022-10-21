using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using OrdersManager.Domain.Models;
using OrdersManager.DTO.Schedule;
using OrdersManager.Interfaces.Services;

namespace OrdersManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchedulesController : ControllerBase
    {
        private readonly ISchedulesService _schedulesService;

        public SchedulesController(ISchedulesService schedulesService)
        {
            _schedulesService = schedulesService;
        }

        #region CRUD

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var schedules = await _schedulesService.GetAll();

            return Ok(schedules);
        }

        [HttpGet("{id}", Name = "ScheduleById")]
        public async Task<IActionResult> Get(Guid id)
        {
            var schedule = await _schedulesService.GetById(id);

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
        public async Task<IActionResult> Create([FromBody] ScheduleForCreationDto schedule)
        {
            if (schedule == null)
            {
                return BadRequest("Object sent from client is null");
            }

            var otherSchedules = await _schedulesService.GetAll();
            var schedulesByDate = otherSchedules.Where(s => s.StartTime.Date.Equals(schedule.StartTime.Date)
                && s.MasterId.Equals(schedule.MasterId));

            if (schedulesByDate.Count() != 0)
            {
                var schedulesByTime = schedulesByDate.Where(s =>
                    (s.StartTime <= schedule.StartTime && s.EndTime >= schedule.StartTime) ||
                    (s.StartTime <= schedule.EndTime && s.EndTime >= schedule.EndTime));

                if (schedulesByTime.Count() != 0)
                {
                    return BadRequest("Selected time is busy!");
                }
            }

            var scheduleEntity = await _schedulesService.Create(schedule);

            return CreatedAtRoute("ScheduleById", new { id = scheduleEntity.Id }, scheduleEntity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] ScheduleForUpdateDto schedule)
        {
            if (schedule == null)
            {
                return BadRequest("Object sent from client is null");
            }

            var isEntityFound = await _schedulesService.Update(id, schedule);

            if (!isEntityFound)
            {
                return NotFound($"Entity with id: {id} doesn't exist in datebase");
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var isEntityFound = await _schedulesService.Delete(id);

            if (!isEntityFound)
            {
                return NotFound($"Entity with id: {id} doesn't exist in the database.");
            }

            return NoContent();
        }

        #endregion

        [HttpGet("Masters/{masterId}")]
        public async Task<IActionResult> GetByMasterId(Guid masterId)
        {
            var schedules = await _schedulesService.GetByMasterId(masterId);

            return Ok(schedules);
        }
    }
}
