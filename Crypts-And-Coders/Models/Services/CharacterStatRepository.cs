using Crypts_And_Coders.Data;
using Crypts_And_Coders.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crypts_And_Coders.Models.Services
{
    public class CharacterStatRepository : ICharacterStat
    {
        private readonly CryptsDbContext _context;

        public CharacterStatRepository(CryptsDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Creates a new characterStat in the database
        /// </summary>
        /// <param name="characterStat">CharacterStat information for creation</param>
        /// <returns>Successful result of characterStat creation</returns>
        public async Task<CharacterStat> Create(CharacterStat characterStat)
        {
            _context.Entry(characterStat).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return characterStat;
        }

        /// <summary>
        /// Delete a characterStat from the database
        /// </summary>
        /// <param name="id">Id of characterStat to be deleted</param>
        /// <returns>Task of completion for characterStat delete</returns>
        public async Task Delete(int charId, int statId)
        {
            CharacterStat characterStat = await _context.StatSheet.FindAsync(charId, statId);
            if (characterStat != null)
            {
                _context.Entry(characterStat).State = EntityState.Deleted;
                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Get a specific characterStat in the database by ID
        /// </summary>
        /// <param name="id">Id of characterStat to search for</param>
        /// <returns>Successful result of specified characterStat</returns>
        public async Task<CharacterStat> GetCharacterStat(int charId, int statId)
        {
            var result = await _context.StatSheet.Where(x => x.CharacterId == charId && x.StatId == statId).FirstOrDefaultAsync();
            return result;
        }

        /// <summary>
        /// Get a list of all characterStats in the database
        /// </summary>
        /// <returns>Successful result with list of characterStats</returns>
        public async Task<List<CharacterStat>> GetCharacterStats(int id)
        {
            List<CharacterStat> result = await _context.StatSheet.Where(x => x.CharacterId == id).Include(x => x.Stat).ToListAsync();
            return result;
        }


        /// <summary>
        /// Update a given characterStat in the database
        /// </summary>
        /// <param name="id">Id of characterStat to be updated</param>
        /// <param name="characterStat">CharacterStat information for update</param>
        /// <returns>Successful result of specified updated characterStat</returns>
        public async Task<CharacterStat> Update(CharacterStat characterStat)
        {
            _context.Entry(characterStat).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return characterStat;
        }
    }
}
