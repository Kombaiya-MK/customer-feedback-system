using AutoMapper;
using CustomerFeedbackSystem.Application.DTOs;
using CustomerFeedbackSystem.Application.Interfaces;
using CustomerFeedbackSystem.Domain.Models;
using CustomerFeedbackSystem.Infrastructure.Interfaces;
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

        public FeedbackService(IRepo<Feedback, int> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
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
            return await _repo.Get(Id);
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
            var feedbacks = await _repo.GetAll();
            return feedbacks.Where(f => f.ProductId == Id).ToList();
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
            return await _repo.Add(feedback);
        }
        #endregion
    }
}
