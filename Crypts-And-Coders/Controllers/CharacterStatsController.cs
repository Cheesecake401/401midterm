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
    [Route("api/Characters")]
    [ApiController]
    public class CharacterStatsController : ControllerBase
    {
        private readonly ICharacterStat _characterStat;

        public CharacterStatsController(ICharacterStat characterStat)
        {
            _characterStat = characterStat;
        }

        // GET: api/CharacterStats
        [HttpGet("{charId}/Stats")]
        public async Task<ActionResult<IEnumerable<CharacterStat>>> GetStatSheet(int charId)
        {
            return await _characterStat.GetCharacterStats(charId);
        }

        // GET: api/CharacterStats/5
        [HttpGet("{charId}/Stats/{statId}")]
        public async Task<ActionResult<CharacterStat>> GetCharacterStat(int charId, int statId)
        {
            var characterStat = await _characterStat.GetCharacterStat(charId, statId);

            if (characterStat == null)
            {
                return NotFound();
            }

            return characterStat;
        }

        // PUT: api/Characters/5/Stats
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{charId}/Stats/{statId}")]
        public async Task<IActionResult> PutCharacterStat(int charId, int statId, CharacterStat characterStat)
        {
            if (statId != characterStat.StatId || charId != characterStat.CharacterId)
            {
                return BadRequest();
            }

            await _characterStat.Update(characterStat);

            return NoContent();
        }

        // POST: api/Characters/5/Stats
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("{charId}/Stats")]
        public async Task<ActionResult<CharacterStat>> PostCharacterStat(int charId, int statId, CharacterStat characterStat)
        {
            await _characterStat.Create(characterStat);

            return CreatedAtAction("GetCharacterStat", new { id = characterStat.StatId }, characterStat);
        }

        // DELETE: api/CharacterStats/5
        [HttpDelete("{charId}/Stats/{statId}")]
        public async Task<ActionResult<CharacterStat>> DeleteCharacterStat(int charId, int statId)
        {
            await _characterStat.Delete(charId, statId);
            return NoContent();
        }
    }
}
