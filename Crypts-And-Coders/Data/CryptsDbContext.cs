using Crypts_And_Coders.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crypts_And_Coders.Data
{
    public class CryptsDbContext : DbContext
    {
        public DbSet<Character> Character { get; set; }
        public DbSet<Enemy> Enemy { get; set; }
        public DbSet<Location> Location { get; set; }

        public CryptsDbContext(DbContextOptions<CryptsDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CharacterInventory>().HasKey(x => new { x.CharacterId, x.ItemId });
            // seed data
            modelBuilder.Entity<Character>().HasData(
                new Character
                {
                    Id = 1,
                    Name = "Galdifor",
                    Species = Species.Elf,
                    Class = Class.Thief
                },

                new Character
                {
                    Id = 2,
                    Name = "Dragorn",
                    Species = Species.Dwarf,
                    Class = Class.Paladin
                },

                new Character
                {
                    Id = 3,
                    Name = "Glen",
                    Species = Species.Human,
                    Class = Class.Bard
                }
            );
        }
    }
}