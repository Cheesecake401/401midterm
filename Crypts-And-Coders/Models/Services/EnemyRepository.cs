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

        public async Task Delete(int id)
        {
            Enemy enemy = await GetEnemy(id);
            _context.Entry(enemy).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<List<Enemy>> GetEnemies()
        {
            var enemy = await _context.Enemy.ToListAsync();
            return enemy;
        }

        public async Task<Enemy> GetEnemy(int id)
        {
            Enemy enemy = await _context.Enemy.FindAsync(id);
            return enemy;
        }

        public async Task<Enemy> Update(Enemy enemy)
        {
            _context.Entry(enemy).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return enemy;
        }
    }
}