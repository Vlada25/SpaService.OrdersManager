using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrdersManager.Domain.Models;
using OrdersManager.DTO.Schedule;
using OrdersManager.Interfaces;

namespace OrdersManager.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SchedulesController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public SchedulesController(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repository = repositoryManager;
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            var schedules = _repository.SchedulesRepository.GetAll(trackChanges: false);
            var schedulesDto = _mapper.Map<IEnumerable<ScheduleDto>>(schedules);

            return Ok(schedulesDto);
        }

        [HttpGet("{id}", Name = "ScheduleById")]
        public IActionResult Get(Guid id)
        {
            var schedule = _repository.SchedulesRepository.GetById(id, trackChanges: false);

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
                return BadRequest("Object sent from user is null");
            }

            var scheduleEntity = _mapper.Map<Schedule>(schedule);

            _repository.SchedulesRepository.Create(scheduleEntity);
            _repository.Save();

            return CreatedAtRoute("ScheduleById", new { id = scheduleEntity.Id }, scheduleEntity);
        }

        [HttpPut]
        public IActionResult Update([FromBody] ScheduleForUpdateDto schedule)
        {
            if (schedule == null)
            {
                return BadRequest("Object sent from user is null");
            }

            var scheduleEntity = _repository.SchedulesRepository.GetById(schedule.Id, trackChanges: true);

            if (scheduleEntity == null)
            {
                return NotFound($"Entity with id: {schedule.Id} doesn't exist in datebase");
            }

            _mapper.Map(schedule, scheduleEntity);
            _repository.Save();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var schedule = _repository.SchedulesRepository.GetById(id, trackChanges: false);

            if (schedule == null)
            {
                return NotFound($"Entity with id: {id} doesn't exist in the database.");
            }

            _repository.SchedulesRepository.Delete(schedule);
            _repository.Save();

            return NoContent();
        }
    }
}
