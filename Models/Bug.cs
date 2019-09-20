using System;
using System.ComponentModel.DataAnnotations;
using BugBox.Interfaces;

namespace BugBox.Models
{
    public class Bug : IBug
    {
        // [Required]
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ReportedDate { get; set; }
        public DateTime? LastModified { get; set; }
        public DateTime? ClosedDate { get; set; }
    }
}