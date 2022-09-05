using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrdersManager.Domain.Models;
using OrdersManager.DTO.Feedback;
using OrdersManager.Interfaces;
using OrdersManager.Interfaces.Services;

namespace OrdersManager.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FeedbacksController : ControllerBase
    {
        private readonly IFeedbacksService _feedbacksService;

        public FeedbacksController(IFeedbacksService feedbacksService)
        {
            _feedbacksService = feedbacksService;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            var feedbacks = _feedbacksService.GetAll();

            return Ok(feedbacks);
        }

        [HttpGet("{id}", Name = "FeedbackById")]
        public IActionResult Get(Guid id)
        {
            var feedback = _feedbacksService.GetById(id);

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

            var feedbackEntity = _feedbacksService.Create(feedback);

            return CreatedAtRoute("FeedbackById", new { id = feedbackEntity.Id }, feedbackEntity);
        }

        [HttpPut]
        public IActionResult Update([FromBody] FeedbackForUpdateDto feedback)
        {
            if (feedback == null)
            {
                return BadRequest("Object sent from client is null");
            }

            var isEntityFound = _feedbacksService.Update(feedback);

            if (!isEntityFound)
            {
                return NotFound($"Entity with id: {feedback.Id} doesn't exist in datebase");
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var isEntityFound = _feedbacksService.Delete(id);

            if (!isEntityFound)
            {
                return NotFound($"Entity with id: {id} doesn't exist in the database.");
            }

            return NoContent();
        }
    }
}
