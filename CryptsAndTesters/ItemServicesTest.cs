using Crypts_And_Coders.Models.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Crypts_And_Coders.Models.Interfaces;
using Crypts_And_Coders.Models;
using Crypts_And_Coders.Data;
using System.Threading.Tasks;
using Crypts_And_Coders.Models.DTOs;

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
                Id = 4,
                Name = "Magic Potion",
                Value = 125
            };

            var repo = BuildRepo();

            ItemDTO newItemDTO = new ItemDTO()
            {
                Id = newItem.Id,
                Name = newItem.Name,
                Value = newItem.Value
            };

            // act
            var createdItem = await repo.Create(newItemDTO);

            // assert
            Assert.NotNull(createdItem);
            Assert.NotEqual(0, createdItem.Id);
            Assert.Equal(4, createdItem.Id);
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
            ItemDTO newItem = new ItemDTO()
            {
                Id = 4,
                Name = "Magic Potion",
                Value = 125
            };

            var repo = BuildRepo();

            ItemDTO newItemDTO = new ItemDTO()
            {
                Id = newItem.Id,
                Name = newItem.Name,
                Value = newItem.Value
            };

            repo.Create(newItemDTO);

            // act
            var result = await repo.GetItem(4);

            // assert
            Assert.NotNull(result);
            Assert.Equal(4, result.Id);
            Assert.Equal("Magic Potion", result.Name);
        }

        [Fact]
        public async Task CanUpdateAnItem()
        {
            // arrange
            ItemDTO newItem = new ItemDTO()
            {
                Id = 4,
                Name = "Magic Potion",
                Value = 125
            };

            ItemDTO newItemDTO = new ItemDTO()
            {
                Id = newItem.Id,
                Name = newItem.Name,
                Value = newItem.Value
            };

            var repo = BuildRepo();
            repo.Create(newItemDTO);
            repo.Update(newItemDTO);

            // act
            var result = await repo.GetItem(4);

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