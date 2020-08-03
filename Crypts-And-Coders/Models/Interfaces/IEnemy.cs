using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crypts_And_Coders.Models.Interfaces
{
    public interface IEnemy
    {
        /// <summary>
        /// Creates a new enemy in the database
        /// </summary>
        /// <param name="enemy">Enemy information for creation</param>
        /// <returns>Successful result of enemy creation</returns>
        Task<Enemy> Create(Enemy enemy);

        /// <summary>
        /// Get a list of all enemies in the database
        /// </summary>
        /// <returns>Successful result with list of enemies</returns>
        Task<List<Enemy>> GetEnemies();

        /// <summary>
        /// Get a specific enemy in the database by ID
        /// </summary>
        /// <param name="id">Id of enemy to search for</param>
        /// <returns>Successful result of specified enemy</returns>
        Task<Enemy> GetEnemy(int id);

        /// <summary>
        /// Update a given enemy in the database
        /// </summary>
        /// <param name="id">Id of enemy to be updated</param>
        /// <param name="enemy">Enemy information for update</param>
        /// <returns>Successful result of specified updated enemy</returns>
        Task<Enemy> Update(int id, Enemy enemy);

        /// <summary>
        /// Delete a enemy from the database
        /// </summary>
        /// <param name="id">Id of enemy to be deleted</param>
        /// <returns>Task of completion for enemy delete</returns>
        Task Delete(int id);
    }
}