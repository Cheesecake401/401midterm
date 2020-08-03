using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Crypts_And_Coders.Models.SpeciesAndClass;

namespace Crypts_And_Coders.Models.DTOs
{
    public class CharacterDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Species Species { get; set; }
        public Class Class { get; set; }
        public Weapon Weapon { get; set; }
        public Location CurrentLocation { get; set; }
        public List<CharacterInventory> Inventory { get; set; }
        public List<CharacterStat> StatSheet { get; set; }
    }
}
