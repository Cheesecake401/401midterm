using Crypts_And_Coders.Data;
using Crypts_And_Coders.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crypts_And_Coders.Models.Services
{
    public class CharacterRepository : ICharacter
    {
        private readonly CryptsDbContext _context;
        private readonly ICharacterStat _characterStat;

        public CharacterRepository(CryptsDbContext context, ICharacterStat characterStat)
        {
            _context = context;
            _characterStat = characterStat;
        }

        /// <summary>
        /// Creates a new character in the database
        /// </summary>
        /// <param name="character">Character information for creation</param>
        /// <returns>Successful result of character creation</returns>
        public async Task<Character> Create(Character character)
        {
            _context.Entry(character).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return character;
        }

        /// <summary>
        /// Delete a character from the database
        /// </summary>
        /// <param name="id">Id of character to be deleted</param>
        /// <returns>Task of completion for character delete</returns>
        public async Task Delete(int id)
        {
            Character character = await _context.Character.FindAsync(id);
            if(character != null)
            {
                _context.Entry(character).State = EntityState.Deleted;
                await _context.SaveChangesAsync();
            } 
        }

        /// <summary>
        /// Get a specific character in the database by ID
        /// </summary>
        /// <param name="id">Id of character to search for</param>
        /// <returns>Successful result of specified character</returns>
        public async Task<Character> GetCharacter(int id)
        {
            var result = await _context.Character.Where(x => x.Id == id)
                                                 .FirstOrDefaultAsync();
            var stats = await _characterStat.GetCharacterStats(id);
            result.StatSheet = stats;
            return result;
        }

        /// <summary>
        /// Get a list of all characters in the database
        /// </summary>
        /// <returns>Successful result with list of characters</returns>
        public async Task<List<Character>> GetCharacters()
        {
            List<Character> result = await _context.Character.ToListAsync();
            foreach (var item in result)
            {
                var stats = await _characterStat.GetCharacterStats(item.Id);
                item.StatSheet = stats;
            }
            return result;
        }


        /// <summary>
        /// Update a given character in the database
        /// </summary>
        /// <param name="id">Id of character to be updated</param>
        /// <param name="character">Character information for update</param>
        /// <returns>Successful result of specified updated character</returns>
        public async Task<Character> Update(Character character)
        {
            _context.Entry(character).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return character;
       }

        /// <summary>
        /// Add an item to a character's inventory
        /// </summary>
        /// <param name="charId">Id of character</param>
        /// <param name="itemId">Id of item</param>
        /// <returns>Successful result of item addition</returns>
        public async Task AddItemToInventory(int charId, int itemId)
        {
            CharacterInventory inventory = new CharacterInventory()
            {
                CharacterId = charId,
                ItemId = itemId
            };

            _context.Entry(inventory).State = EntityState.Added;
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Remove an item from a character's inventory
        /// </summary>
        /// <param name="charId">Id of character</param>
        /// <param name="itemId">Id of item</param>
        /// <returns>Successful result of item removal</returns>
        public async Task RemoveItemFromInventory(int charId, int itemId)
        {
            CharacterInventory result = await _context.CharacterInventory.FindAsync(charId, itemId);

            if (result != null)
            {
                _context.Entry(result).State = EntityState.Deleted;
                await _context.SaveChangesAsync();
            }
        }

    }
}
