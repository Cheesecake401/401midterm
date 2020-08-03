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

        public CharacterRepository(CryptsDbContext context)
        {
            _context = context;
        }

        public async Task<Character> Create(Character character)
        {
            _context.Entry(character).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return character;
        }

        public async Task Delete(int id)
        {
            Character character = await _context.Character.FindAsync(id);
            if (character != null)
            {
                _context.Entry(character).State = EntityState.Deleted;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Character> GetCharacter(int id)
        {
            var result = await _context.Character.Where(x => x.Id == id).FirstOrDefaultAsync();
            return result;
        }

        public async Task<List<Character>> GetCharacters()
        {
            List<Character> result = await _context.Character.ToListAsync();
            return result;
        }

        public async Task<Character> Update(Character character)
        {
            _context.Entry(character).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return character;
        }

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