using System;

namespace BugBox.Interfaces
{
    public interface IBugNote
    {
        string Id { get; set; }
        string BugId { get; set; }
        string Body { get; set; }
        DateTime Timestamp { get; set; }
    }
}