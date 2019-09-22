using System;
using System.ComponentModel.DataAnnotations;
using BugBox.Interfaces;

namespace BugBox.Models
{
    public class BugNote : IBugNote
    {
        // [Required]
        public string Id { get; set; }

        // [Required]
        public string BugId { get; set; }
        public string Body { get; set; }
        public DateTime Timestamp { get; set; }
    }
}