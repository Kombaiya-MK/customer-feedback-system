﻿using System.Diagnostics.CodeAnalysis;

namespace CustomerFeedbackSystem.Application.DTOs
{
    [ExcludeFromCodeCoverage]
    public class SubmitFeedbackDTO
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int Rating { get; set; }
        public string? Comment { get; set; }

    }
}
