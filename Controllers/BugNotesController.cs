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
    public class BugNotesController : ControllerBase
    {
        private readonly BugNotesService _bns;

        // GET api/values
        // [HttpGet("{id}")]
        // public ActionResult<IEnumerable<BugNote>> Get(string id)
        // {
        //     try
        //     {
        //         return Ok(_bns.GetBugNotesById(id));
        //     }
        //     catch (Exception e)
        //     {
        //         return BadRequest(e.Message);
        //     }
        // }

        // GET api/values/5
        // [HttpGet("{id}")]
        // public ActionResult<Bug> Get(string id)
        // {
        //     try
        //     {
        //         return _bs.GetBugById(id);
        //     }
        //     catch (Exception e)
        //     {
        //         return BadRequest(e.Message);
        //     }
        // }

        // POST api/values
        [HttpPost]
        public ActionResult<BugNote> Post([FromBody] BugNote bugNoteData)
        {
            try
            {
                BugNote bugNote = _bns.AddBugNote(bugNoteData);
                return Ok(bugNote);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult<BugNote> Put(string id, [FromBody] BugNote bugNoteData)
        {
            try
            {
                bugNoteData.Id = id;
                return Ok(_bns.EditBugNote(bugNoteData));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        public BugNotesController(BugNotesService bns)
        {
            _bns = bns;
        }
    }
}
