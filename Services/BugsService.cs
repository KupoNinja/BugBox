using System;
using System.Collections.Generic;
using BugBox.Data;
using BugBox.Models;

namespace BugBox.Services
{
    public class BugsService
    {
        private readonly FakeDb _repo;

        public List<Bug> GetBugs()
        {
            return _repo.Bugs;
        }

        public Bug GetBugById(string id)
        {
            var bug = _repo.Bugs.Find(b => b.Id == id);
            if (bug == null) { throw new Exception("Get yer eyes checked, buddy. This Id doesn't exist."); }

            return bug;
        }

        public Bug AddBug(Bug bugData)
        {
            var exists = _repo.Bugs.Find(b => b.Title == bugData.Title);
            if (exists != null)
            {
                throw new Exception("This bug already exists.");
            }
            bugData.Id = Guid.NewGuid().ToString();
            bugData.ReportedDate = DateTime.Now;
            _repo.Bugs.Add(bugData);

            return bugData;
        }

        public Bug EditBug(Bug bugData)
        {
            var bug = GetBugById(bugData.Id);
            if (bug.ClosedDate != null) { throw new Exception("Quit wasting time... This bug is already resolved!"); }
            bug.LastModified = DateTime.Now;
            bug.Title = bugData.Title;
            bug.Description = bugData.Description;

            return bug;
        }

        public BugsService(FakeDb repo)
        {
            _repo = repo;
        }
    }
}