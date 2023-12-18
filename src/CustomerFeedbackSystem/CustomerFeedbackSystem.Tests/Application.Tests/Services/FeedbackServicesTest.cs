using AutoMapper;
using CustomerFeedbackSystem.Application.DTOs;
using CustomerFeedbackSystem.Application.Services;
using CustomerFeedbackSystem.Domain.Models;
using CustomerFeedbackSystem.Infrastructure.Extensions;
using CustomerFeedbackSystem.Infrastructure.Interfaces;
using Microsoft.Extensions.Caching.Distributed;
using Moq;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerFeedbackSystem.Tests.Application.Tests.Services
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class FeedbackServicesTest
    {
        private Mock<IRepo<Feedback, int>> _repoMock;
        private Mock<IMapper> _mapperMock;
        private Mock<IDistributedCache> _cacheMock;
        private FeedbackService _serviceMock;

        [SetUp]
        public void SetUp()
        {
            _repoMock = new Mock<IRepo<Feedback, int>>();
            _mapperMock = new Mock<IMapper>();
            _cacheMock = new Mock<IDistributedCache>();

            _serviceMock = new FeedbackService(_repoMock.Object, _mapperMock.Object, _cacheMock.Object);
        }
        [Test]
        public async Task GetFeedbackById_Returns_FeedbackObject()
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

            _cacheMock.Setup(x => x.GetFromCacheAsync<Feedback>($"feedbackKey_{id}")).ReturnsAsync(feedback);    
            _repoMock.Setup(r => r.Get(1)).ReturnsAsync(feedback);

            //Act
            var result = await _serviceMock.GetFeedbackAsync(1);
            Assert.Multiple(() =>
            {

                //Assert
                Assert.That(result, Is.Not.Null);
                Assert.That(feedback.Comment, Is.EqualTo(result.Comment));
            });
            Assert.Multiple(() =>
            {
                Assert.That(feedback.UserId, Is.EqualTo(result.UserId));
                Assert.That(feedback.ProductId, Is.EqualTo(result.ProductId));
            });
            Assert.That(result.Rating, Is.EqualTo(feedback.Rating));
        }

        [Test]
        public async Task GetFeedbacksByProductId_Returns_Feedbacks()
        {
            //Arrange
            List<Feedback> feedbackList = new()
            {
              new Feedback { FeedbackId = 1, UserId = 1, ProductId = 1, Rating = 5, Comment = "Great", Timestamp = DateTime.Now },
              new Feedback { FeedbackId = 2, UserId = 2, ProductId = 2, Rating = 4, Comment = "Good", Timestamp = DateTime.Now.AddDays(-1) },
              new Feedback { FeedbackId = 3, UserId = 3, ProductId = 1, Rating = 3, Comment = "Okay", Timestamp = DateTime.Now.AddDays(-2) },
              new Feedback { FeedbackId = 4, UserId = 1, ProductId = 2, Rating = 5, Comment = "Excellent", Timestamp = DateTime.Now.AddDays(-3) },
              new Feedback { FeedbackId = 5, UserId = 2, ProductId = 1, Rating = 2, Comment = "Poor", Timestamp = DateTime.Now.AddDays(-4) },
            };

            //_cacheMock.Setup(x => x.)
            _repoMock.Setup( r => r.GetAll()).ReturnsAsync(feedbackList );

            //Act
            var result = await _serviceMock.GetFeedbacksByProductAsync(1);

            //Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Has.Count.EqualTo(3));
        }

        [Test]
        public async Task InsertFeedback_Returns_Feedback()
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

            SubmitFeedbackDTO submitFeedbackDTO = new ()
            {
                UserId = 1,
                ProductId = 1,
                Rating = 5,
                Comment = "Great",
            };

            _mapperMock.Setup(m => m.Map<Feedback>(submitFeedbackDTO)).Returns(feedback);  
            _repoMock.Setup(r => r.Add(feedback)).ReturnsAsync(feedback);

            //Act
            var result = await _serviceMock.InsertFeedbackAsync(submitFeedbackDTO);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.Null);
                Assert.That(feedback.Comment, Is.EqualTo(result.Comment));
            });
            Assert.Multiple(() =>
            {
                Assert.That(feedback.Timestamp, Is.EqualTo(result.Timestamp));
                Assert.That(feedback.FeedbackId, Is.EqualTo(result.FeedbackId));
            });
        }
    }
}
