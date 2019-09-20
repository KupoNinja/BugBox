using System.Collections.Generic;
using BugBox.Models;

namespace BugBox.Data
{
    public class FakeDb
    {
        public List<Bug> Bugs { get; set; }
        public List<BugNote> BugNotes { get; set; }
    }
}