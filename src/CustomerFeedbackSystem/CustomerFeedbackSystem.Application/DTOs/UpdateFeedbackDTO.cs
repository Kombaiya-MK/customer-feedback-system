using System.Diagnostics.CodeAnalysis;

namespace CustomerFeedbackSystem.Application.DTOs
{
    [ExcludeFromCodeCoverage]
    public class UpdateFeedbackDTO
    {
        public int FeedbackId { get; set; }
        public int Rating { get; set; }
        public string? Comment { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}