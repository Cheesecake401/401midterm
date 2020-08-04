using Crypts_And_Coders.Models.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Crypts_And_Coders.Models.Interfaces;
using Crypts_And_Coders.Models;
using Crypts_And_Coders.Data;
using System.Threading.Tasks;

namespace CryptsAndTesters
{
    public class ItemServicesTest : DatabaseTest
    {
        private IItem BuildRepo()
        {
            return new ItemRepository(_db);
        }

        [Fact]
        public async Task CanCreateANewItem()
        {
            // arrange
            Item newItem = new Item()
            {
                Id = 5,
                Name = "Magic Potion",
                Value = 125
            };

            var repo = BuildRepo();

            // act
            var createdItem = await repo.Create(newItem);

            // assert
            Assert.NotNull(createdItem);
            Assert.NotEqual(0, createdItem.Id);
            Assert.Equal(5, createdItem.Id);
            Assert.Equal("Magic Potion", createdItem.Name);
        }

        [Fact]
        public async Task CanGetAllItems()
        {
            // arrange
            var repo = BuildRepo();

            // act
            var result = await repo.GetItems();

            // assert
            Assert.Equal(3, result.Count);
        }

        [Fact]
        public async Task CanGetSingleItem()
        {
            // arrange
            Item newItem = new Item()
            {
                Id = 5,
                Name = "Magic Potion",
                Value = 125
            };

            var repo = BuildRepo();
            repo.Create(newItem);

            // act
            var result = await repo.GetItem(5);

            // assert
            Assert.NotNull(result);
            Assert.Equal(5, result.Id);
            Assert.Equal("Magic Potion", result.Name);
        }

        [Fact]
        public async Task CanUpdateAnItem()
        {
            // arrange
            Item newItem = new Item()
            {
                Id = 5,
                Name = "Magic Potion",
                Value = 125
            };

            var repo = BuildRepo();
            repo.Create(newItem);
            repo.Update(newItem);

            // act
            var result = await repo.GetItem(5);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(newItem.Id, result.Id);
            Assert.Equal(newItem.Name, result.Name);
        }

        [Fact]
        public async Task CanDeleteItem()
        {
            // arrange
            var repo = BuildRepo();

            // act
            repo.Delete(3);
            var result = await repo.GetItems();

            // assert
            Assert.Equal(2, result.Count);
        }
    }
}