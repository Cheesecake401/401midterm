using Crypts_And_Coders.Data;
using Crypts_And_Coders.Models.DTOs;
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
        /// <param name="enemyDTO">enemy information for creation</param>
        /// <returns>Successful result of enemy creation</returns>
        public async Task<EnemyDTO> Create(EnemyDTO enemyDTO)
        {
            Enemy enemy = new Enemy()
            {
                Id = enemyDTO.Id,
                Abilities = enemyDTO.Abilities,
                Type = enemyDTO.Type,
                Species = enemyDTO.Species
            };

            _context.Entry(enemy).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return enemyDTO;
        }

        /// <summary>
        /// Delete a enemy from the database
        /// </summary>
        /// <param name="id">Id of enemy to be deleted</param>
        /// <returns>Task of completion for enemy delete</returns>
        public async Task Delete(int id)
        {
            Enemy enemy = await _context.Enemy.FindAsync(id);
            if (enemy != null)
            {
                _context.Entry(enemy).State = EntityState.Deleted;
                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Get a list of all enemies in the database
        /// </summary>
        /// <returns>Successful result with list of enemies</returns>
        public async Task<List<EnemyDTO>> GetEnemies()
        {
            List<Enemy> enemies = await _context.Enemy.ToListAsync();
            List<EnemyDTO> enemyDTO = new List<EnemyDTO>();

            foreach (var item in enemies)
            {
                enemyDTO.Add(await GetEnemy(item.Id));
            }

            return enemyDTO;
        }

        /// <summary>
        /// Get a specific enemy in the database by ID
        /// </summary>
        /// <param name="id">Id of enemy to search for</param>
        /// <returns>Successful result of specified enemy</returns>
        public async Task<EnemyDTO> GetEnemy(int id)
        {
            Enemy enemy = await _context.Enemy.Where(x => x.Id == id).FirstOrDefaultAsync();

            EnemyDTO enemyDTO = new EnemyDTO()
            {
                Id = enemy.Id,
                Abilities = enemy.Abilities,
                Type = enemy.Type,
                Species = enemy.Species
            };

            return enemyDTO;
        }

        /// <summary>
        /// Update a given enemy in the database
        /// </summary>
        /// <param name="enemyDTO">Enemy information for update</param>
        /// <returns>Successful result of specified updated enemy</returns>
        public async Task<EnemyDTO> Update(EnemyDTO enemy)
        {
            EnemyDTO enemyDTO = new EnemyDTO()
            {
                Id = enemy.Id,
                Abilities = enemy.Abilities,
                Type = enemy.Type,
                Species = enemy.Species
            };

            _context.Entry(enemy).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return enemyDTO;
        }
    }
}