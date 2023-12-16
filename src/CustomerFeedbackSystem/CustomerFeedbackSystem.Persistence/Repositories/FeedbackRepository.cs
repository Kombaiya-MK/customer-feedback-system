using CustomerFeedbackSystem.Infrastructure.Interfaces;
using CustomerFeedbackSystem.Domain.Models;
using CustomerFeedbackSystem.Infrastructure.Context;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace CustomerFeedbackSystem.Infrastructure.Repositories
{
    public class FeedbackRepository : IRepo<Feedback, int>
    {
        #region Constructor
        private readonly FeedbackContext _context;

        public FeedbackRepository(FeedbackContext context)
        {
            _context = context;
        }

        #endregion

        #region Repository Method for Add Feedback
        /// <summary>
        /// Repository Method for Add Feedback
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <exception cref="NullReferenceException"></exception>
        public async Task<Feedback> Add(Feedback entity)
        {
            var query = "INSERT INTO FEEDBACKS VALUES (@UserId, @ProductId, @Rating, @Comment, @Timestamp)";

            var parameters = new DynamicParameters();
            parameters.Add("UserId", entity.UserId, DbType.Int32);
            parameters.Add("ProductId", entity.ProductId, DbType.Int32);
            parameters.Add("Rating", entity.Rating, DbType.Int32);
            parameters.Add("Comment", entity.Comment, DbType.String);
            parameters.Add("Timestamp", DateTime.Now, DbType.DateTime);

            using (var connection = _context.CreateConnection())
            {
                if (entity != null)
                    await connection.ExecuteAsync(query, parameters);
                else
                    throw new NullReferenceException("Empty data being passed");
            };
            entity.Timestamp = DateTime.Now;
            return entity;
        }
        #endregion

        #region Repository Method for Get Single Feedback
        /// <summary>
        /// Repository Method for Get Single Feedback 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NullReferenceException"></exception>
        public async Task<Feedback> Get(int id)
        {
            var query = "SELECT * FROM FEEDBACKS WHERE FeedbackId = @id";

            using (var connection = _context.CreateConnection())
            {
                var feedback = await connection.QuerySingleOrDefaultAsync<Feedback>(query, new { id });
                if (feedback != null)
                    return feedback;
                else
                    throw new NullReferenceException("Invalid Id");
            }
        }
        #endregion

        #region Repository Method for Get Feedbacks
        /// <summary>
        /// Repository Method for Get Feedbacks
        /// </summary>
        /// <returns></returns>
        public async Task<List<Feedback>> GetAll()
        {
            var query = "SELECT * FROM FEEDBACKS";

            using (var connection = _context.CreateConnection())
            {
                var feedbacks = await connection.QueryAsync<Feedback>(query);
                return feedbacks.ToList();
            }
        }
        #endregion

    }
}