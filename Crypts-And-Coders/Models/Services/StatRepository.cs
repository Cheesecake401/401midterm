using Crypts_And_Coders.Data;
using Crypts_And_Coders.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crypts_And_Coders.Models.Services
{
    public class StatRepository : IStat
    {
        private readonly CryptsDbContext _context;

        public StatRepository(CryptsDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Creates a new stat in the database
        /// </summary>
        /// <param name="stat">Stat information for creation</param>
        /// <returns>Successful result of stat creation</returns>
        public async Task<Stat> Create(Stat stat)
        {
            _context.Entry(stat).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return stat;
        }

        /// <summary>
        /// Delete a stat from the database
        /// </summary>
        /// <param name="id">Id of stat to be deleted</param>
        /// <returns>Task of completion for stat delete</returns>
        public async Task Delete(int id)
        {
            Stat stat = await _context.Stat.FindAsync(id);
            if (stat != null)
            {
                _context.Entry(stat).State = EntityState.Deleted;
                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Get a list of all stats in the database
        /// </summary>
        /// <returns>Successful result with list of stats</returns>
        public async Task<Stat> GetStat(int id)
        {
            var result = await _context.Stat.Where(x => x.Id == id).FirstOrDefaultAsync();
            return result;
        }

        /// <summary>
        /// Get a list of all stats in the database
        /// </summary>
        /// <returns>Successful result with list of stats</returns>
        public async Task<List<Stat>> GetStats()
        {
            List<Stat> result = await _context.Stat.ToListAsync();
            return result;
        }

        /// <summary>
        /// Update a given stat in the database
        /// </summary>
        /// <param name="id">Id of stat to be updated</param>
        /// <param name="stat">Stat information for update</param>
        /// <returns>Successful result of specified updated stat</returns>
        public async Task<Stat> Update(Stat stat)
        {
            _context.Entry(stat).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return stat;
        }
    }
}
