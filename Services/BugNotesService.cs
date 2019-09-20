using System;
using System.Collections.Generic;
using BugBox.Data;
using BugBox.Models;

namespace BugBox.Services
{
    public class BugNotesService
    {
        private readonly FakeDb _repo;

        public List<BugNote> GetBugNotes()
        {
            return _repo.BugNotes;
        }

        // public Bug GetBugById(string id)
        // {
        //     var bug = _repo.Bugs.Find(b => b.Id == id);
        //     if (bug == null) { throw new Exception("Get yer eyes checked, buddy. This Id doesn't exist."); }

        //     return bug;
        // }

        public Bug AddBugNote(BugNote bugNoteData)
        {
            var exists = _repo.Bugs.Find(b => b.Title == bugNoteData.Id);
            if (exists != null)
            {
                throw new Exception("This bug already exists.");
            }
            bugNoteData.Id = Guid.NewGuid().ToString();
            bugNoteData.Timestamp = DateTime.Now;
            _repo.Bugs.Add(bugNoteData);

            return bugNoteData;
        }

        // public Bug EditBug(Bug bugData)
        // {
        //     var bug = GetBugById(bugData.Id);
        //     if (bug.ClosedDate != null) { throw new Exception("Quit wasting time... This bug is already resolved!"); }
        //     bug.LastModified = DateTime.Now;
        //     bug.Title = bugData.Title;
        //     bug.Description = bugData.Description;

        //     return bug;
        // }

        // public Bug CloseBug(string id)
        // {
        //     var bug = GetBugById(id);
        //     if (bug.ClosedDate != null) { throw new Exception("Quit wasting time... This bug is already resolved!"); }
        //     bug.LastModified = DateTime.Now;
        //     bug.ClosedDate = DateTime.Now;

        //     return bug;
        // }

        public BugNotesService(FakeDb repo)
        {
            _repo = repo;
        }
    }
}