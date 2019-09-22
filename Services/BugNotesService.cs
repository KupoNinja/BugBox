using System;
using System.Collections.Generic;
using BugBox.Data;
using BugBox.Models;

namespace BugBox.Services
{
    public class BugNotesService
    {
        private readonly FakeDb _repo;
        // private readonly BugsService _bs;

        public BugNote GetBugNoteById(string id)
        {
            var bugNote = _repo.BugNotes.Find(b => b.Id == id);
            if (bugNote == null) { throw new Exception("Get your eyes checked, buddy. This Id doesn't exist."); }

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

        // NOTE Edits note but for some reason shows original note when pulling up note for specific bug
        public BugNote EditBugNote(BugNote bugNoteData)
        {
            var bug = GetBugById(bugNoteData.BugId);
            if (bug.ClosedDate != null) { throw new Exception("Quit wasting time... This bug is already resolved!"); }
            bugNoteData.Timestamp = DateTime.Now;
            bugNoteData.Body = bugNoteData.Body;

            return bugNoteData;
        }

        public BugNotesService(FakeDb repo)
        {
            _repo = repo;
        }
    }
}