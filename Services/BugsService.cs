using System;
using System.Collections.Generic;
using System.Linq;
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

        public List<BugNote> GetBugNotes(string id)
        {
            var bug = GetBugById(id);
            List<BugNote> bugNotes = _repo.BugNotes.FindAll(bn => bn.BugId == bug.Id);
            if (!bugNotes.Any()) { throw new Exception("No notes on this one. Work harder!"); }

            return bugNotes;
        }

        public Bug AddBug(Bug bugData)
        {
            var exists = _repo.Bugs.Find(b => b.Id == bugData.Id);
            if (exists != null) { throw new Exception("This bug already exists."); }
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

        public Bug CloseBug(string id)
        {
            var bug = GetBugById(id);
            if (bug.ClosedDate != null) { throw new Exception("Quit wasting time... This bug is already resolved!"); }
            bug.LastModified = DateTime.Now;
            bug.ClosedDate = DateTime.Now;

            return bug;
        }

        public BugsService(FakeDb repo)
        {
            _repo = repo;
        }
    }
}