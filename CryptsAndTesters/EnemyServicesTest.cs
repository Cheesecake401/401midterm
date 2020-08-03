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
    public class EnemyServicesTest : DatabaseTest
    {
        private IEnemy BuildRepo()
        {
            return new EnemyRepository(_db);
        }


        [Fact]
        public async Task CanSaveEnemy()
        {
            Enemy enemy = new Enemy()
            {
                Id = 4,
                Abilities = "Fire",
                Type = "Warrior",
            };
            var repo = BuildRepo();

            var saved = await repo.Create(enemy);

            Assert.NotNull(saved);
            Assert.NotEqual(0, saved.Id);
            Assert.Equal(saved.Id, enemy.Id);
            Assert.Equal(saved.Abilities, enemy.Abilities);
            Assert.Equal(saved.Type, enemy.Type);
        }
    }
}
