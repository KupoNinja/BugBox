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
            if (bugNote == null) { throw new Exception("Get yer eyes checked, buddy. This Id doesn't exist."); }

            return bugNote;
        }

        public Bug GetBugById(string id)
        {
            var bug = _repo.Bugs.Find(b => b.Id == id);
            if (bug == null) { throw new Exception("Get your eyes checked, buddy. This Id doesn't exist."); }

            return bug;
        }

        public BugNote AddBugNote(string bugId, BugNote bugNoteData)
        {
            // NOTE Do check for if bug is closed
            // NOTE Need to check Note.BugId to Bug.Id
            var bug = GetBugById(bugId);
            var bugNote = GetBugNoteById(bugNoteData.Id);
            if (bugNote == null) { throw new Exception("Get yer eyes checked, buddy. This note doesn't exist."); }
            if (bug.ClosedDate != null) { throw new Exception("Quit wasting time... This bug is already resolved!"); }
            bugNoteData.Id = Guid.NewGuid().ToString();
            bugNoteData.Timestamp = DateTime.Now;
            _repo.BugNotes.Add(bugNoteData);

            return bugNoteData;
        }

        public BugNote EditBugNote(string bugId, BugNote bugNoteData)
        {
            var bug = GetBugById(bugId);
            var bugNote = GetBugNoteById(bugNoteData.Id);
            if (bugNote == null) { throw new Exception("Get yer eyes checked, buddy. This note doesn't exist."); }
            if (bug.ClosedDate != null) { throw new Exception("Quit wasting time... This bug is already resolved!"); }
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