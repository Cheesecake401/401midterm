using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Crypts_And_Coders.Data;
using Crypts_And_Coders.Models;
using Crypts_And_Coders.Models.Interfaces;

namespace Crypts_And_Coders.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatsController : ControllerBase
    {
        private readonly IStat _stat;

        public StatsController(IStat stat)
        {
            _stat = stat;
        }

        // GET: api/Stats
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Stat>>> GetStat()
        {
            return await _stat.GetStats();
        }

        // GET: api/Stats/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Stat>> GetStat(int id)
        {
            var stat = await _stat.GetStat(id);

            if (stat == null)
            {
                return NotFound();
            }

            return stat;
        }

        // PUT: api/Stats/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStat(int id, Stat stat)
        {
            if (id != stat.Id)
            {
                return BadRequest();
            }

            var result = await _stat.Update(stat);

            return Ok(result);
        }

        // POST: api/Stats
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Stat>> PostStat(Stat stat)
        {
            await _stat.Create(stat);

            return CreatedAtAction("GetStat", new { id = stat.Id }, stat);
        }

        // DELETE: api/Stats/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Stat>> DeleteStat(int id)
        {
            await _stat.Delete(id);

            return NoContent();
        }
    }
}
