using AutoMapper;
using CustomerFeedbackSystem.Application.DTOs;
using CustomerFeedbackSystem.Domain.Models;

namespace CustomerFeedbackSystem.Application.Mappers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() {
            CreateMap<SubmitFeedbackDTO, Feedback>();
            CreateMap<UpdateFeedbackDTO, Feedback>();
        }
    }
}
