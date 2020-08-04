using Crypts_And_Coders.Models;
using Crypts_And_Coders.Models.Interfaces;
using Crypts_And_Coders.Models.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using static Crypts_And_Coders.Models.SpeciesAndClass;

namespace CryptsAndTesters
{
    public class CharacterServicesTest : DatabaseTest
    {
        private ICharacter BuildRepo()
        {
            return new CharacterRepository(_db, _characterStat);
        }

        [Fact]
        public async Task CanSaveCharacter()
        {
            Character newChar = new Character()
            {
                Id = 4,
                Name = "Redhawk",
                Species = Species.Dragonborn,
                Class = Class.Monk,
                WeaponId = 1,
                LocationId = 1
            };
            var repo = BuildRepo();

            var saved = await repo.Create(newChar);

            Assert.NotNull(saved);
            Assert.NotEqual(0, saved.Id);
            Assert.Equal(saved.Id, newChar.Id);
            Assert.Equal(saved.Name, newChar.Name);
        }

        [Fact]
        public async Task CanGetCharacter()
        {
            Character newChar = new Character()
            {
                Id = 4,
                Name = "Redhawk",
                Species = Species.Dragonborn,
                Class = Class.Monk,
                WeaponId = 1,
                LocationId = 1
            };
            var repo = BuildRepo();

            repo.Create(newChar);

            var result = await repo.GetCharacter(newChar.Id);

            Assert.Equal(newChar.Id, result.Id);
        }

        [Fact]
        public async Task CanGetAllCharacters()
        {
            var repo = BuildRepo();

            var result = await repo.GetCharacters();

            // Three from seeded data
            Assert.Equal(3, result.Count);
        }

        [Fact]
        public async Task CanUpdateCharacter()
        {
            Character newChar = new Character()
            {
                Id = 1,
                Name = "Redhawk",
                Species = Species.Dragonborn,
                Class = Class.Monk,
                WeaponId = 2,
                LocationId = 3
            };
            var repo = BuildRepo();

            await repo.Update(newChar);

            var result = await repo.GetCharacter(1);

            Assert.Equal(1, result.Id);
            Assert.Equal(newChar.Name, result.Name);

        }

        [Fact]
        public async Task CanDeleteCharacter()
        {
            var repo = BuildRepo();

            repo.Delete(1);

            var count = await repo.GetCharacters();

            Assert.Equal(2, count.Count);
        }
    }
}
