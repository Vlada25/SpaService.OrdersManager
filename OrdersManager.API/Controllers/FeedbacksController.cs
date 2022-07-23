using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrdersManager.Domain.Models;
using OrdersManager.DTO.Feedback;
using OrdersManager.Interfaces;

namespace OrdersManager.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FeedbacksController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public FeedbacksController(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repository = repositoryManager;
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            var feedbacks = _repository.FeedbacksRepository.GetAll(trackChanges: false);

            return Ok(feedbacks);
        }

        [HttpGet("{id}", Name = "FeedbackById")]
        public IActionResult Get(Guid id)
        {
            var feedback = _repository.FeedbacksRepository.GetById(id, trackChanges: false);

            if (feedback == null)
            {
                return NotFound($"Entity with id: {id} doesn't exist in datebase");
            }
            else
            {
                return Ok(feedback);
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] FeedbackForCreationDto feedback)
        {
            if (feedback == null)
            {
                return BadRequest("Object sent from client is null");
            }

            var feedbackEntity = _mapper.Map<Feedback>(feedback);

            _repository.FeedbacksRepository.Create(feedbackEntity);
            _repository.Save();

            return CreatedAtRoute("FeedbackById", new { id = feedbackEntity.Id }, feedbackEntity);
        }

        [HttpPut]
        public IActionResult Update([FromBody] FeedbackForUpdateDto feedback)
        {
            if (feedback == null)
            {
                return BadRequest("Object sent from client is null");
            }

            var feedbackEntity = _repository.FeedbacksRepository.GetById(feedback.Id, trackChanges: true);

            if (feedbackEntity == null)
            {
                return NotFound($"Entity with id: {feedback.Id} doesn't exist in datebase");
            }

            _mapper.Map(feedback, feedbackEntity);
            _repository.Save();

            return Ok("Entity was updated");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var feedback = _repository.FeedbacksRepository.GetById(id, trackChanges: false);

            if (feedback == null)
            {
                return NotFound($"Entity with id: {id} doesn't exist in the database.");
            }

            _repository.FeedbacksRepository.Delete(feedback);
            _repository.Save();

            return Ok("Entity was deleted");
        }
    }
}
