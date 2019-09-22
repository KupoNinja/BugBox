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

        [HttpGet("api/bugs/{bugId}/notes/{id}")]
        public ActionResult<BugNote> Get(string id)
        {
            try
            {
                return _bns.GetBugNoteById(id);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("api/bugs/{bugId}/notes")]
        public ActionResult<BugNote> Post(string bugId, [FromBody] BugNote bugNoteData)
        {
            try
            {
                BugNote bugNote = _bns.AddBugNote(bugId, bugNoteData);
                return Ok(bugNote);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("api/bugs/{bugId}/notes/{id}")]
        public ActionResult<BugNote> Put(string bugId, string id, [FromBody] BugNote bugNoteData)
        {
            try
            {
                bugNoteData.Id = id;
                return Ok(_bns.EditBugNote(bugId, bugNoteData));
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
