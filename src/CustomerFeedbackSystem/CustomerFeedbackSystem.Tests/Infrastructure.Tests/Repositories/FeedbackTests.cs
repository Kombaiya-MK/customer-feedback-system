
using CustomerFeedbackSystem.Domain.Models;
using CustomerFeedbackSystem.Infrastructure.Context;
using CustomerFeedbackSystem.Infrastructure.Repositories;
using Dapper;
using Moq;
using System.Data;

namespace CustomerFeedbackSystem.Tests.Infrastructure.Tests.Repositories
{
    [TestFixture]
    public class FeedbackTests
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
        public async Task AddFeedback_ActualObject_ReturnsObject()
        {
            //Arrange
            Feedback feedback = new()
            {
                FeedbackId = 1,
                ProductId = 1,
                UserId = 1, 
                Comment = "Great",
                Rating = 5,
                Timestamp = DateTime.Now,
            };

            _connectionMock.Setup(con => con.ExecuteAsync(It.IsAny<string>(), It.IsAny<object>(), null, null, null)).ReturnsAsync(1);
            //Act

            //Assert
        }
    }
}
