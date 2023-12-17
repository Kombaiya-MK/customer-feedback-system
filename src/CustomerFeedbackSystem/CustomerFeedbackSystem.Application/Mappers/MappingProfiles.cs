using AutoMapper;
using CustomerFeedbackSystem.Application.DTOs;
using CustomerFeedbackSystem.Domain.Models;
using System.Diagnostics.CodeAnalysis;

namespace CustomerFeedbackSystem.Application.Mappers
{
    [ExcludeFromCodeCoverage]
    public class MappingProfiles : Profile
    {
        public MappingProfiles() {
            CreateMap<SubmitFeedbackDTO, Feedback>();
            CreateMap<UpdateFeedbackDTO, Feedback>();
        }
    }
}
