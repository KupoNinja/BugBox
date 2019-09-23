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

        [HttpGet("{id}")]
        public ActionResult<BugNote> Get(string id)
        {
            try
            {
                return Ok(_bns.GetBugNoteById(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public ActionResult<BugNote> Post([FromBody] BugNote bugNoteData)
        {
            try
            {
                return Ok(_bns.AddBugNote(bugNoteData));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

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
