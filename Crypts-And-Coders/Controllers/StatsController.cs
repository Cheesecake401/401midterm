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
using Crypts_And_Coders.Models.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace Crypts_And_Coders.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "GameMaster")]
    public class StatsController : ControllerBase
    {
        private readonly IStat _stat;

        public StatsController(IStat stat)
        {
            _stat = stat;
        }

        // GET: api/Stats
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<StatDTO>>> GetStats()
        {
            return await _stat.GetStats();
        }

        // GET: api/Stats/5
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<StatDTO>> GetStat(int id)
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
        public async Task<IActionResult> PutStat(int id, StatDTO stat)
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
        public async Task<ActionResult<StatDTO>> PostStat(StatDTO stat)
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
