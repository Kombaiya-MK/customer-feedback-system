using CustomerFeedbackSystem.API.Controllers;
using CustomerFeedbackSystem.Application.DTOs;
using CustomerFeedbackSystem.Application.Interfaces;
using CustomerFeedbackSystem.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerFeedbackSystem.Tests.API.Tests.Controllers
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class FeedbackControllerTest
    {
        private Mock<IFeedbackService> _serviceMock;
        private FeedbackController _controllerMock;

        [SetUp] 
        public void SetUp() 
        {
            _serviceMock = new Mock<IFeedbackService>();
            _controllerMock = new FeedbackController(_serviceMock.Object);

        }
        #region Test Methods for Get Feedback By Id
        [Test]
        public async Task GetFeedbackById_Returns_OkResult()
        {
            //Arrange
            Feedback feedback = new()
            {
                FeedbackId = 1,
                UserId = 1,
                ProductId = 1,
                Rating = 5,
                Comment = "Great",
                Timestamp = DateTime.Now,
            };
            int id = 1;

            _serviceMock.Setup(s => s.GetFeedbackAsync(id)).ReturnsAsync(feedback);

            //Act
            var result = await _controllerMock.GetFeedbacksById(id);

            //Assert
            Assert.That(result, Is.InstanceOf<ActionResult<Feedback>>());
            var actionResult = result as ActionResult<Feedback>;
            Assert.That(actionResult.Result, Is.InstanceOf<OkObjectResult>());
            var okResult = actionResult.Result as OkObjectResult;
            Assert.That(okResult, Is.Not.Null);
            Assert.That(okResult.StatusCode, Is.EqualTo(StatusCodes.Status200OK));
        }

        [Test]
        public async Task GetFeedbackById_Returns_NotFoundResult()
        {
            //Assign
            Feedback feedback = null;
            int id = 1;

            _serviceMock.Setup(s => s.GetFeedbackAsync(id)).ReturnsAsync(feedback);

            //Act
            var result = await _controllerMock.GetFeedbacksById(id);

            //Assert
            Assert.That(result, Is.InstanceOf<ActionResult<Feedback>>());
            var actionResult = result as ActionResult<Feedback>;
            Assert.That(actionResult.Result, Is.InstanceOf<NotFoundObjectResult>());
            var notFoundObject = actionResult.Result as NotFoundObjectResult;
            Assert.That(notFoundObject.StatusCode, Is.EqualTo(StatusCodes.Status404NotFound));

        }
        #endregion

        #region Test Methods for Get Feedbacks by Product
        [Test]
        public async Task GetFeedbacksByProduct_Returns_OkResult()
        {
            //Arrange
            List<Feedback> feedbacks = new()
            {
              new Feedback { FeedbackId = 1, UserId = 1, ProductId = 1, Rating = 5, Comment = "Great", Timestamp = DateTime.Now },
              new Feedback { FeedbackId = 3, UserId = 3, ProductId = 1, Rating = 3, Comment = "Okay", Timestamp = DateTime.Now.AddDays(-2) },
              new Feedback { FeedbackId = 5, UserId = 2, ProductId = 1, Rating = 2, Comment = "Poor", Timestamp = DateTime.Now.AddDays(-4) },
            };
            int id = 1;

            _serviceMock.Setup(s => s.GetFeedbacksByProductAsync(id)).ReturnsAsync(feedbacks);

            //Act
            var result = await _controllerMock.GetFeedbacks(id);

            //Assert
            Assert.That(result, Is.InstanceOf<ActionResult<ICollection<Feedback>>>());
            var actionResult = result as ActionResult<ICollection<Feedback>>;
            Assert.That(actionResult.Result, Is.InstanceOf<OkObjectResult>());
            var okResult = actionResult.Result as OkObjectResult;
            Assert.That(okResult, Is.Not.Null);
            Assert.That(okResult.StatusCode, Is.EqualTo(StatusCodes.Status200OK));
        }

        [Test]
        public async Task GetFeedbacksByProduct_Returns_NotFoundResult()
        {
            //Assign
            List<Feedback> feedbacks = new();
            int id = 1;

            _serviceMock.Setup(s => s.GetFeedbacksByProductAsync(id)).ReturnsAsync(feedbacks);

            //Act
            var result = await _controllerMock.GetFeedbacks(id);

            //Assert
            Assert.That(result, Is.InstanceOf<ActionResult<ICollection<Feedback>>>());
            var actionResult = result as ActionResult<ICollection<Feedback>>;
            Assert.That(actionResult.Result, Is.InstanceOf<NotFoundObjectResult>());
            var notFoundObject = actionResult.Result as NotFoundObjectResult;
            Assert.That(notFoundObject.StatusCode, Is.EqualTo(StatusCodes.Status404NotFound));

        }
        #endregion

        #region Test Methods for Insert Feedback
        [Test]
        public async Task InsertFeedback_Returns_OkResult()
        {
            //Arrange
            Feedback feedback = new()
            {
                FeedbackId = 1,
                UserId = 1,
                ProductId = 1,
                Rating = 5,
                Comment = "Great",
                Timestamp = DateTime.Now,
            };
            SubmitFeedbackDTO submitFeedbackDTO = new()
            {
                UserId = 1,
                ProductId = 1,
                Rating = 5,
                Comment = "Great",
            };

            _serviceMock.Setup(s => s.InsertFeedbackAsync(submitFeedbackDTO)).ReturnsAsync(feedback);

            //Act
            var result = await _controllerMock.InsertFeedback(submitFeedbackDTO);

            //Assert
            Assert.That(result, Is.InstanceOf<ActionResult<Feedback>>());
            var actionResult = result as ActionResult<Feedback>;
            Assert.That(actionResult.Result, Is.InstanceOf<CreatedResult>());
            var createdResult = actionResult.Result as CreatedResult;
            Assert.That(createdResult, Is.Not.Null);
            Assert.That(createdResult.StatusCode, Is.EqualTo(StatusCodes.Status201Created));

        }

        [Test]
        public async Task InsertFeedback_Returns_BadRequestResult()
        {
            //Arrange
            Feedback feedback = null;
            SubmitFeedbackDTO feedbackDTO = null;

            _serviceMock.Setup( s => s.InsertFeedbackAsync(feedbackDTO)).ReturnsAsync(feedback);

            //Act
            var result = await _controllerMock.InsertFeedback(feedbackDTO);

            //Assert
            Assert.That(result, Is.InstanceOf<ActionResult<Feedback>>());
            var actionResult = result as ActionResult<Feedback>;
            Assert.That(actionResult.Result, Is.InstanceOf<BadRequestObjectResult>());
            var badRequestResult = actionResult.Result as BadRequestObjectResult;
            Assert.That(badRequestResult.StatusCode, Is.EqualTo(StatusCodes.Status400BadRequest));
        }


        #endregion

    }
}
