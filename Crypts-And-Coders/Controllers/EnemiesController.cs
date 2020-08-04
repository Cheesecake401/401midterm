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

namespace Crypts_And_Coders.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnemiesController : ControllerBase
    {
        private readonly IEnemy _enemy;

        public EnemiesController(IEnemy enemy)
        {
            _enemy = enemy;
        }

        // GET: api/Enemies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EnemyDTO>>> GetEnemies()
        {
            return await _enemy.GetEnemies();
        }

        // GET: api/Enemies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EnemyDTO>> GetEnemy(int id)
        {
            var enemy = await _enemy.GetEnemy(id);

            if (enemy == null)
            {
                return NotFound();
            }

            return enemy;
        }

        // PUT: api/Enemies/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEnemy(int id, EnemyDTO enemy)
        {
            if (id != enemy.Id)
            {
                return BadRequest();
            }
            var result = await _enemy.Update(enemy);

            return Ok(result);
        }

        // POST: api/Enemies
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<EnemyDTO>> PostEnemy(EnemyDTO enemy)
        {
            await _enemy.Create(enemy);

            return CreatedAtAction("GetEnemy", new { id = enemy.Id }, enemy);
        }

        // DELETE: api/Enemies/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Enemy>> DeleteEnemy(int id)
        {
            await _enemy.Delete(id);
            return NoContent();
        }
    }
}