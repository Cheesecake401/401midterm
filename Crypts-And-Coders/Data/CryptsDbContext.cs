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
    public class CryptsDbContext : IdentityDbContext
    {
        public CryptsDbContext(DbContextOptions<CryptsDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // seed data
            modelBuilder.Entity<Character>().HasData(
                new Character
                {
                    Name = "Galdifor",
                    Species = Species.Elf,
                    Class = Class.Thief
                },

                new Character
                {
                    Name = "Dragorn",
                    Species = Species.Dwarf,
                    Class = Class.Paladin
                },

                new Character
                {
                    Name = "Glen",
                    Species = Species.Human,
                    Class = Class.Bard
                }
            );
        }
    }
}