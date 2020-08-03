using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crypts_And_Coders.Models.Interfaces
{
    public interface IEnemy
    {
        //Create a enemy
        Task<Enemy> Create(Enemy enemy);
        //Read a enemy/Get
        Task<List<Enemy>> GetEnemies();
        //Get by enemy id
        Task<Enemy> GetEnemies(int id);
        //Update a enemy
        Task<Enemy> Update(Enemy enemy);
        //Delete a enemy
        Task Delete(int id);
    }
}
