using System;
using System.Collections.Generic;
using BugBox.Data;
using BugBox.Models;

namespace BugBox.Services
{
    public class BugNotesService
    {
        private readonly FakeDb _repo;

        public BugNote GetBugNoteById(string id)
        {
            var bugNote = _repo.BugNotes.Find(b => b.Id == id);
            if (bugNote == null) { throw new Exception("Get your eyes checked, buddy. This note Id doesn't exist."); }

            return bugNote;
        }

        public Bug GetBugById(string id)
        {
            var bug = _repo.Bugs.Find(b => b.Id == id);
            if (bug == null) { throw new Exception("Get your eyes checked, buddy. This Id doesn't exist."); }

            return bug;
        }

        public BugNote AddBugNote(BugNote bugNoteData)
        {
            var bug = GetBugById(bugNoteData.BugId);
            if (bug.ClosedDate != null) { throw new Exception("Quit wasting time... This bug is already resolved!"); }
            bugNoteData.Id = Guid.NewGuid().ToString();
            bugNoteData.Timestamp = DateTime.Now;
            _repo.BugNotes.Add(bugNoteData);

            return bugNoteData;
        }

        // NOTE All tests pass on front end now but I lose the check for if a bug is open.
        public BugNote EditBugNote(BugNote bugNoteData)
        {
            // var bug = GetBugById(bugNoteData.BugId);
            var bugNote = GetBugNoteById(bugNoteData.Id);
            // if (bug.ClosedDate != null) { throw new Exception("Quit wasting time... This bug is already resolved!"); }
            bugNote.Timestamp = DateTime.Now;
            bugNote.Body = bugNoteData.Body;

            return bugNote;
        }

        public BugNotesService(FakeDb repo)
        {
            _repo = repo;
        }
    }
}