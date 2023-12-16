using CustomerFeedbackSystem.Application.DTOs;
using CustomerFeedbackSystem.Application.Interfaces;
using CustomerFeedbackSystem.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerFeedbackSystem.API.Controllers
{
    [Route("api/feedbacks")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {

        #region Constructor
        private readonly IFeedbackService _service;

        public FeedbackController(IFeedbackService service)
        {
            _service = service;
        }
        #endregion

        #region Endpoint to Get Feedbacks by Product Id
        [HttpGet("product/{id}", Name = "FeedbackByProductId")]
        public async Task<ActionResult<ICollection<Feedback>>> GetFeedbacks(int id)
        {
            var feedbacks = await _service.GetFeedbacksByProductAsync(id);
            return Ok(feedbacks);
        }
        #endregion

        #region Endpoint to Get Feedbacks by Feedback Id

        [HttpGet("{id}", Name = "FeedbackByFeedbackId")]
        public async Task<ActionResult<Feedback>> GetFeedbacksById(int id)
        {
            var feedback = await _service.GetFeedbackAsync(id);
            return Ok(feedback);
        }
        #endregion

        #region Endpoint to Insert Feedback
        [HttpPost]
        public async Task<ActionResult<Feedback>> InsertFeedback(SubmitFeedbackDTO feedbackDTO)
        {
            var feedback = await _service.InsertFeedbackAsync(feedbackDTO);
            if(feedback != null)
            {
                return Ok("Feedback Added Successfully");
            }
            return BadRequest("Unable to add");
            
        }
        #endregion

    }
}
