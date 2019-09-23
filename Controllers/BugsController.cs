using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BugBox.Models;
using BugBox.Services;
using Microsoft.AspNetCore.Mvc;

namespace BugBox.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BugsController : ControllerBase
    {
        private readonly BugsService _bs;

        [HttpGet]
        public ActionResult<IEnumerable<Bug>> Get()
        {
            try
            {
                return Ok(_bs.GetBugs());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Bug> Get(string id)
        {
            try
            {
                return Ok(_bs.GetBugById(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}/notes")]
        public ActionResult<IEnumerable<BugNote>> GetNotes(string id)
        {
            try
            {
                return Ok(_bs.GetBugNotes(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public ActionResult<Bug> Post([FromBody] Bug bugData)
        {
            try
            {
                return Ok(_bs.AddBug(bugData));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Bug> Put(string id, [FromBody] Bug bugData)
        {
            try
            {
                bugData.Id = id;
                return Ok(_bs.EditBug(bugData));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // NOTE Is this really an HttpDelete if it doesn't delete the bug?
        [HttpDelete("{id}")]
        public ActionResult<Bug> CloseBug(string id)
        {
            try
            {
                return Ok(_bs.CloseBug(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        public BugsController(BugsService bs)
        {
            _bs = bs;
        }
    }
}
