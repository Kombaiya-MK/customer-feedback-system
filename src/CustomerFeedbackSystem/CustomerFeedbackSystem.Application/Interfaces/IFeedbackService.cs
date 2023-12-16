using CustomerFeedbackSystem.Application.DTOs;
using CustomerFeedbackSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerFeedbackSystem.Application.Interfaces
{
    public interface IFeedbackService 
    {
        Task<Feedback> InsertFeedbackAsync(SubmitFeedbackDTO submitFeedbackDTO);
        Task<Feedback> GetFeedbackAsync(int Id);
        Task<ICollection<Feedback>> GetFeedbacksByProductAsync(int Id);



    }
}
