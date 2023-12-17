
using CustomerFeedbackSystem.Domain.Models;
using CustomerFeedbackSystem.Infrastructure.Context;
using CustomerFeedbackSystem.Infrastructure.Repositories;
using Dapper;
using Moq;
using System.Data;
using System.Diagnostics.CodeAnalysis;

namespace CustomerFeedbackSystem.Tests.Infrastructure.Tests.Repositories
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class FeedbackRepoTests
    {
        private Mock<FeedbackContext> _contextMock;
        private Mock<IDbConnection> _connectionMock;
        private FeedbackRepository _feedbackRepo;

        [SetUp] 
        public void SetUp() {
            _contextMock = new Mock<FeedbackContext>();
            _connectionMock = new Mock<IDbConnection>();
            _contextMock.Setup(context => context.CreateConnection()).Returns(_connectionMock.Object);


            _feedbackRepo = new FeedbackRepository(_contextMock.Object); 
        }
        [Test]
        public async Task Add_ShouldInsertFeedbackSuccessfully()
        {
            // Arrange
            Feedback feedback = new()
            {
                UserId = 1,
                ProductId = 1,
                Rating = 5,
                Comment = "Great",
                Timestamp = DateTime.Now,
            };

            _connectionMock.Setup(conn => conn.ExecuteAsync(It.IsAny<string>(), It.IsAny<object>(), null, null, null))
                          .ReturnsAsync(1);

            // Act
            var result = await _feedbackRepo.Add(feedback);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(feedback.UserId, result.UserId);
            Assert.AreEqual(feedback.ProductId, result.ProductId);
            Assert.AreEqual(feedback.Rating, result.Rating);
            Assert.AreEqual(feedback.Comment, result.Comment);
            Assert.IsNotNull(result.Timestamp);
        }
    }
}
