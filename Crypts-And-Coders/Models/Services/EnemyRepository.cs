using Crypts_And_Coders.Data;
using Crypts_And_Coders.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crypts_And_Coders.Models.Services
{
    public class EnemyRepository : IEnemy
    {
        private CryptsDbContext _context;

        public EnemyRepository(CryptsDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Creates a new enemy in the database
        /// </summary>
        /// <param name="enemy">enemy information for creation</param>
        /// <returns>Successful result of enemy creation</returns>
        public async Task<Enemy> Create(Enemy enemy)
        {
            Enemy entity = new Enemy()
            {
                Id = enemy.Id,
                Abilities = enemy.Abilities,
                Type = enemy.Type,
                Species = SpeciesAndClass.Species.Dragon
            };

            _context.Entry(enemy).State = EntityState.Added;
            await _context.SaveChangesAsync();

            enemy.Id = entity.Id;
            return enemy;
        }

        /// <summary>
        /// Delete a enemy from the database
        /// </summary>
        /// <param name="id">Id of enemy to be deleted</param>
        /// <returns>Task of completion for enemy delete</returns>
        public async Task Delete(int id)
        {
            Enemy enemy = await GetEnemy(id);
            _context.Entry(enemy).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Get a list of all enemies in the database
        /// </summary>
        /// <returns>Successful result with list of enemies</returns>
        public async Task<List<Enemy>> GetEnemies()
        {
            var enemy = await _context.Enemy.ToListAsync();
            return enemy;
        }

        /// <summary>
        /// Get a specific enemy in the database by ID
        /// </summary>
        /// <param name="id">Id of enemy to search for</param>
        /// <returns>Successful result of specified enemy</returns>
        public async Task<Enemy> GetEnemy(int id)
        {
            Enemy enemy = await _context.Enemy.FindAsync(id);
            return enemy;
        }

        /// <summary>
        /// Update a given enemy in the database
        /// </summary>
        /// <param name="id">Id of enemy to be updated</param>
        /// <param name="enemy">Enemy information for update</param>
        /// <returns>Successful result of specified updated enemy</returns>
        public async Task<Enemy> Update(Enemy enemy)
        {
            _context.Entry(enemy).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return enemy;
        }
    }
}