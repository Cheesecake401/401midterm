﻿using Crypts_And_Coders.Models.DTOs;
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
        /// <param name="enemyDTO">Enemy information for creation</param>
        /// <returns>Successful result of enemy creation</returns>
        Task<EnemyDTO> Create(EnemyDTO enemy);

        /// <summary>
        /// Get a list of all enemies in the database
        /// </summary>
        /// <returns>Successful result with list of enemies</returns>
        Task<List<EnemyDTO>> GetEnemies();

        /// <summary>
        /// Get a specific enemy in the database by ID
        /// </summary>
        /// <param name="id">Id of enemy to search for</param>
        /// <returns>Successful result of specified enemy</returns>
        Task<EnemyDTO> GetEnemy(int id);

        /// <summary>
        /// Update a given enemy in the database
        /// </summary>
        /// <param name="enemyDTO">Enemy information for update</param>
        /// <returns>Successful result of specified updated enemy</returns>
        Task<EnemyDTO> Update(EnemyDTO enemy);

        /// <summary>
        /// Delete a character from the database
        /// </summary>
        /// <param name="id">Id of character to be deleted</param>
        /// <returns>Task of completion for character delete</returns>
        Task Delete(int id);
    }
}