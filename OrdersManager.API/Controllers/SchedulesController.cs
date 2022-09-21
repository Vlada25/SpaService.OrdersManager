using Microsoft.AspNetCore.Mvc;
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
    }
}
