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

        public BugsService(FakeDb repo)
        {
            _repo = repo;
        }
    }
}