using Crypts_And_Coders.Models;
using Crypts_And_Coders.Models.Interfaces;
using Crypts_And_Coders.Models.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CryptsAndTesters
{
    public class CharacterServicesTest : DatabaseTest
    {
        private ICharacter BuildRepo()
        {
            return new CharacterRepository(_db);
        }

        [Fact]
        public async Task CanSaveAndGetCharacter()
        {
            Character newChar = new Character()
            {
                Name = "Redhawk",
                Species = Species.Dragonborn,
                Class = Class.Monk,
            };
            var repo = BuildRepo();

            var saved = await repo.Create(newChar);

            Assert.NotNull(saved);
            Assert.NotEqual(0, saved.Id);
            Assert.Equal(saved.Id, newChar.Id);
            Assert.Equal(saved.Name, newChar.Name);
        }
    }
}
