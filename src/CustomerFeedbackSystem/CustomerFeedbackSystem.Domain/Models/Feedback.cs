using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerFeedbackSystem.Domain.Models
{
    [ExcludeFromCodeCoverage]
    public class Feedback
    {
        [Required(ErrorMessage = "Feedback Id is required")]
        public int FeedbackId { get; set; }

        [Required(ErrorMessage = "User Id is required")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Product Id is required")]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Rating is required")]
        public int Rating { get; set; }

        [MinLength(1)]
        public string? Comment { get; set; }

        [Required(ErrorMessage = "Timestamp is required")]
        public DateTime Timestamp { get; set; }
    }
}
