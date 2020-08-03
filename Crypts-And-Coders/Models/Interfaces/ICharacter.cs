using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crypts_And_Coders.Models.Interfaces
{
    public interface ICharacter
    {
        /// <summary>
        /// Creates a new character in the database
        /// </summary>
        /// <param name="character">Character information for creation</param>
        /// <returns>Successful result of character creation</returns>
        Task<Character> Create(Character character);

        /// <summary>
        /// Get a list of all characters in the database
        /// </summary>
        /// <returns>Successful result with list of characters</returns>
        Task<List<Character>> GetCharacters();

        /// <summary>
        /// Get a specific character in the database by ID
        /// </summary>
        /// <param name="id">Id of character to search for</param>
        /// <returns>Successful result of specified character</returns>
        Task<Character> GetCharacter(int id);

        /// <summary>
        /// Update a given character in the database
        /// </summary>
        /// <param name="character">Character information for update</param>
        /// <returns>Successful result of specified updated character</returns>
        Task<Character> Update(Character character);

        /// <summary>
        /// Delete a character from the database
        /// </summary>
        /// <param name="id">Id of character to be deleted</param>
        /// <returns>Task of completion for character delete</returns>
        Task Delete(int id);

        /// <summary>
        /// Add an item to a character's inventory
        /// </summary>
        /// <param name="charId">Id of character</param>
        /// <param name="itemId">Id of item</param>
        /// <returns>Successful result of item addition</returns>
        Task AddItemToInventory(int charId, int itemId);

        /// <summary>
        /// Remove an item from a character's inventory
        /// </summary>
        /// <param name="charId">Id of character</param>
        /// <param name="itemId">Id of item</param>
        /// <returns>Successful result of item removal</returns>
        Task RemoveItemFromInventory(int charId, int itemId);
    }
}