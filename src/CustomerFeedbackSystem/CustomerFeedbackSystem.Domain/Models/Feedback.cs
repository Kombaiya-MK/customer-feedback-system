using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerFeedbackSystem.Domain.Models
{
    public class Feedback
    {
        [Required]
        public int FeedbackId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public int Rating { get; set; }

        [Required]
        [MinLength(1)]
        public string? Comment { get; set; }

        [Required]
        public DateTime Timestamp { get; set; }
    }
}
