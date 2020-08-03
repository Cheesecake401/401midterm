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
    public class StatServicesTest : DatabaseTest
    {
        private IStat BuildRepo()
        {
            return new StatRepository(_db);
        }

        [Fact]
        public async Task CanSaveStat()
        {
            Stat newStat = new Stat()
            {
                Id = 4,
                Name = "Agility",
            };
            var repo = BuildRepo();

            var saved = await repo.Create(newStat);

            Assert.NotNull(saved);
            Assert.NotEqual(0, saved.Id);
            Assert.Equal(saved.Id, newStat.Id);
            Assert.Equal(saved.Name, newStat.Name);
        }

        [Fact]
        public async Task CanGetStat()
        {
            Stat newStat = new Stat()
            {
                Id = 4,
                Name = "Agility"
            };
            var repo = BuildRepo();

            var saved = await repo.Create(newStat);

            var result = await repo.GetStat(newStat.Id);

            Assert.Equal(newStat.Id, result.Id);
        }

        [Fact]
        public async Task CanGetAllStats()
        {
            var repo = BuildRepo();

            var result = await repo.GetStats();

            // Three from seeded data
            Assert.Equal(3, result.Count);
        }

        [Fact]
        public async Task CanUpdateStat()
        {
            Stat newStat = new Stat()
            {
                Id = 1,
                Name = "StatUpdate"
            };
            var repo = BuildRepo();

            await repo.Update(newStat);

            var result = await repo.GetStat(1);

            Assert.Equal(1, result.Id);
            Assert.Equal(newStat.Name, result.Name);

        }

        [Fact]
        public async Task CanDeleteStat()
        {
            var repo = BuildRepo();

            repo.Delete(1);

            var count = await repo.GetStats();

            Assert.Equal(2, count.Count);
        }
    }
}
