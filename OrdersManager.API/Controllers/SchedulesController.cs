﻿using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrdersManager.CQRS.Commands.Schedules;
using OrdersManager.CQRS.Queries.Schedules;

namespace OrdersManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchedulesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SchedulesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #region CRUD

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var schedules = await _mediator.Send(new GetAllSchedulesQuery());

            return Ok(schedules);
        }

        [HttpGet("{id}", Name = "ScheduleById")]
        public async Task<IActionResult> Get(Guid id)
        {
            var schedule = await _mediator.Send(new GetScheduleByIdQuery
            {
                Id = id
            });

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
        public async Task<IActionResult> Create([FromBody] CreateScheduleCommand schedule)
        {
            if (schedule == null)
            {
                return BadRequest("Object sent from client is null");
            }

            var otherSchedules = await _mediator.Send(new GetAllSchedulesQuery());
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

            var scheduleEntity = await _mediator.Send(schedule);

            return CreatedAtRoute("ScheduleById", new { id = scheduleEntity.Id }, scheduleEntity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateScheduleCommand schedule)
        {
            if (schedule == null)
            {
                return BadRequest("Object sent from client is null");
            }

            schedule.Id = id;
            var isEntityFound = await _mediator.Send(schedule);

            if (!isEntityFound)
            {
                return NotFound($"Entity with id: {id} doesn't exist in datebase");
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var isEntityFound = await _mediator.Send(new DeleteScheduleCommand
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

        [HttpGet("Masters/{masterId}")]
        public async Task<IActionResult> GetByMasterId(Guid masterId)
        {
            var schedules = await _mediator.Send(new GetSchedulesByMasterIdQuery
            {
                MasterId = masterId
            });

            return Ok(schedules);
        }

        [HttpGet("Services/{serviceId}")]
        public async Task<IActionResult> GetByServiceId(Guid serviceId)
        {
            var schedules = await _mediator.Send(new GetSchedulesByServiceIdQuery
            {
                ServiceId = serviceId
            });

            return Ok(schedules);
        }
    }
}
