namespace CustomerFeedbackSystem.Application.DTOs
{
    public class UpdateFeedbackDTO
    {
        public int FeedbackId { get; set; }
        public int Rating { get; set; }
        public string? Comment { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}