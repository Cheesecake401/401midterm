using Crypts_And_Coders.Data;
using Crypts_And_Coders.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crypts_And_Coders.Models.Services
{
    public class EnemyRepository : IEnemy
    {
    private CryptsDbContext _context;
        public Task<Enemy> Create(Enemy enemy)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Enemy>> GetEnemies()
        {
            throw new NotImplementedException();
        }

        public Task<Enemy> GetEnemies(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Enemy enemy)
        {
            throw new NotImplementedException();
        }
    }
}
