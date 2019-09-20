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

        // GET api/values
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

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Bug> Get(string id)
        {
            try
            {
                return _bs.GetBugById(id);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST api/values
        [HttpPost]
        public ActionResult<Bug> Post([FromBody] Bug bugData)
        {
            try
            {
                Bug bug = _bs.AddBug(bugData);
                return Ok(bug);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT api/values/5
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

        // DELETE api/values/5
        [HttpPut("{id}/close")]
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
