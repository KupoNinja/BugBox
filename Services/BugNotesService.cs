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

        // public List<BugNote> GetBugNotes()
        // {
        //     return _repo.BugNotes;
        // }

        private BugNote GetBugNoteById(string id)
        {
            var bugNote = _repo.BugNotes.Find(b => b.Id == id);
            if (bugNote == null) { throw new Exception("Get yer eyes checked, buddy. This Id doesn't exist."); }

            return bugNote;
        }

        public BugNote AddBugNote(BugNote bugNoteData)
        {
            // NOTE Do check for if bug is closed
            // NOTE Need to check Note.BugId to Bug.Id
            var exists = _repo.BugNotes.Find(b => b.Id == bugNoteData.Id);
            if (exists != null) { throw new Exception("This note already exists."); }
            bugNoteData.Id = Guid.NewGuid().ToString();
            bugNoteData.Timestamp = DateTime.Now;
            _repo.BugNotes.Add(bugNoteData);

            return bugNoteData;
        }

        public BugNote EditBugNote(BugNote bugNoteData)
        {
            // NOTE Do a check for if a bug is closed
            var bugNote = GetBugNoteById(bugNoteData.Id);
            // if (bug.ClosedDate != null) { throw new Exception("Quit wasting time... This bug is already resolved!"); }
            bugNote.Timestamp = DateTime.Now;
            bugNote.Body = bugNoteData.Body;

            return bugNote;
        }

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