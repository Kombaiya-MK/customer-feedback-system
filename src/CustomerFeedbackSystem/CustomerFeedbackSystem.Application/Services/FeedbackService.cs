using AutoMapper;
using CustomerFeedbackSystem.Application.DTOs;
using CustomerFeedbackSystem.Application.Interfaces;
using CustomerFeedbackSystem.Domain.Models;
using CustomerFeedbackSystem.Infrastructure.Extensions;
using CustomerFeedbackSystem.Infrastructure.Interfaces;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerFeedbackSystem.Application.Services
{
    public class FeedbackService : IFeedbackService
    {
        #region Constructor
        private readonly IRepo<Feedback, int> _repo;
        private readonly IMapper _mapper;
        private readonly IDistributedCache _cache;

        public FeedbackService(IRepo<Feedback, int> repo, IMapper mapper, IDistributedCache cache)
        {
            _repo = repo;
            _mapper = mapper;
            _cache = cache;
        }
        #endregion

        #region Method to Get Feedback by Id
        /// <summary>
        /// Method to Get Feedback by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<Feedback> GetFeedbackAsync(int Id)
        {
            var cachedFeedback = await _cache.GetFromCacheAsync<Feedback>($"feedbackKey_{Id}");
            if (cachedFeedback != null)
            {
                return cachedFeedback;
            }
            
            var feedback = await _repo.Get(Id);
            await _cache.SetInCacheAsync($"feedbackKey_{Id}", feedback);
            return feedback;
        }
        #endregion

        #region Method to Get Feedbacks by Products
        /// <summary>
        /// Method to Get Feedbacks by Products
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<ICollection<Feedback>> GetFeedbacksByProductAsync(int Id)
        {
            var cachedFeedbacks = await _cache.GetFromCacheAsync<ICollection<Feedback>>($"feedbacksByProductKey_{Id}");
            if (cachedFeedbacks != null)
            {
                return cachedFeedbacks;
            }
            var feedbacks = await _repo.GetAll();
            var filteredFeedbacks =  feedbacks.Where(f => f.ProductId == Id).ToList();
            await _cache.SetInCacheAsync($"feedbacksByProductKey_{Id}", filteredFeedbacks);
            return filteredFeedbacks;
        }
        #endregion

        #region Method to Insert Feedbacks
        /// <summary>
        /// Method to Insert Feedbacks
        /// </summary>
        /// <param name="submitFeedbackDTO"></param>
        /// <returns></returns>

        public async Task<Feedback> InsertFeedbackAsync(SubmitFeedbackDTO submitFeedbackDTO)
        {
            var feedback = _mapper.Map<Feedback>(submitFeedbackDTO);
            var insertedFeedback = await _repo.Add(feedback);
            await _cache.InvalidateCacheAsync("FeedbackKey");
            return insertedFeedback;
        }
        #endregion
    }
}
