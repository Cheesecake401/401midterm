using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crypts_And_Coders.Models.Interfaces
{
    public interface IEnemies
    {
        //Create a enemy
        Task<Enemies> Create(Enemies enemies);
        //Read a enemy/Get
        Task<List<Enemies>> GetEnemies();
        //Get by enemy id
        Task<Enemies> GetEnemies(int id);
        //Update a enemy
        Task Update(Enemies enemies);
        //Delete a enemy
        Task Delete(int id);
    }
}
