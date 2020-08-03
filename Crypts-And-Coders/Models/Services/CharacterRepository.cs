using Crypts_And_Coders.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crypts_And_Coders.Models.Services
{
    public class CharacterRepository : ICharacter
    {
        public Task<CharacterInventory> AddItemToInventory(int charId, int itemId)
        {
            throw new NotImplementedException();
        }

        public Task<Character> Create(Character character)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Character> GetCharacter(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Character>> GetCharacters()
        {
            throw new NotImplementedException();
        }

        public Task<CharacterInventory> RemoveItemFromInventory(int charId, int itemId)
        {
            throw new NotImplementedException();
        }

        public Task<Character> Update(int id, Character character)
        {
            throw new NotImplementedException();
        }
    }
}
