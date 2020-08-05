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
using static Crypts_And_Coders.Models.Services.UserServices;
using Microsoft.AspNetCore.Authorization;

namespace Crypts_And_Coders.Controllers
{
    [Route("api/Characters")]
    [Authorize(Policy = "AllUsers")]
    [ApiController]
    public class CharacterStatsController : ControllerBase
    {
        private readonly ICharacterStat _characterStat;
        private readonly ICharacter _character;

        public CharacterStatsController(ICharacterStat characterStat, ICharacter character)
        {
            _characterStat = characterStat;
            _character = character;
        }

        // GET: api/Characters/5/Stats
        [HttpGet("{charId}/Stats")]
        public async Task<ActionResult<IEnumerable<CharacterStatDTO>>> GetStatSheet(int charId)
        {
            if (!await ValidateUser(User, _character, charId))
            {
                return BadRequest("You do not have access to this account");
            }
            return await _characterStat.GetCharacterStats(charId);
        }

        // GET: api/CharacterStats/5
        [HttpGet("{charId}/Stats/{statId}")]
        public async Task<ActionResult<CharacterStatDTO>> GetCharacterStat(int charId, int statId)
        {
            if (!await ValidateUser(User, _character, charId))
            {
                return BadRequest("You do not have access to this account");
            }
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
        public async Task<IActionResult> PutCharacterStat(int charId, int statId, CharacterStatDTO characterStat)
        {
            if (!await ValidateUser(User, _character, charId))
            {
                return BadRequest("You do not have access to this account");
            }

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
        public async Task<ActionResult<CharacterStat>> PostCharacterStat(int charId, CharacterStatDTO characterStat)
        {
            if (!await ValidateUser(User, _character, charId))
            {
                return BadRequest("You do not have access to this account");
            }

            await _characterStat.Create(characterStat);

            return CreatedAtAction("GetCharacterStat", new { id = characterStat.StatId }, characterStat);
        }

        // DELETE: api/Characters/5/Stats/1
        [HttpDelete("{charId}/Stats/{statId}")]
        public async Task<ActionResult<CharacterStat>> DeleteCharacterStat(int charId, int statId)
        {
            if (!await ValidateUser(User, _character, charId))
            {
                return BadRequest("You do not have access to this account");
            }

            await _characterStat.Delete(charId, statId);
            return NoContent();
        }
    }
}
