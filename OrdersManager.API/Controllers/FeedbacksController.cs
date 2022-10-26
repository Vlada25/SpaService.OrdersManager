using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrdersManager.Database.Commands.Feedbacks;
using OrdersManager.Database.Queries.Feedbacks;
using OrdersManager.DTO.Feedback;
using OrdersManager.Interfaces.Services;

namespace OrdersManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbacksController : ControllerBase
    {
        private readonly IFeedbacksService _feedbacksService;
        private readonly IMediator _mediator;

        public FeedbacksController(IFeedbacksService feedbacksService,
            IMediator mediator)
        {
            _feedbacksService = feedbacksService;
            _mediator = mediator;
        }

        #region CRUD

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var feedbacks = await _mediator.Send(new GetAllFeedbacksQuery());

            return Ok(feedbacks);
        }

        [HttpGet("{id}", Name = "FeedbackById")]
        public async Task<IActionResult> Get(Guid id)
        {
            var feedback = await _mediator.Send(new GetFeedbackByIdQuery
            {
                Id = id
            });

            if (feedback == null)
            {
                return NotFound($"Entity with id: {id} doesn't exist in datebase");
            }

            return Ok(feedback);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] FeedbackForCreationDto feedback)
        {
            if (feedback == null)
            {
                return BadRequest("Object sent from client is null");
            }

            var feedbackEntity = await _mediator.Send(new CreateFeedbackCommand
            {
                Comment = feedback.Comment,
                Mark = feedback.Mark,
                OrderId = feedback.OrderId
            });

            return CreatedAtRoute("FeedbackById", new { id = feedbackEntity.Id }, feedbackEntity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] FeedbackForUpdateDto feedback)
        {
            if (feedback == null)
            {
                return BadRequest("Object sent from client is null");
            }

            var isEntityFound = await _mediator.Send(new UpdateFeedbackCommand
            {
                Id = id,
                Comment = feedback.Comment,
                Mark = feedback.Mark
            });

            if (!isEntityFound)
            {
                return NotFound($"Entity with id: {id} doesn't exist in datebase");
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var isEntityFound = await _mediator.Send(new DeleteFeedbackCommand
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

        [HttpGet("Orders/{orderId}")]
        public async Task<IActionResult> GetByOrderId(Guid orderId)
        {
            var feedbacks = await _mediator.Send(new GetFeedbacksByOrderIdQuery
            {
                OrderId = orderId
            });

            return Ok(feedbacks);
        }
    }
}
