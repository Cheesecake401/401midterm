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
        public string Species { get; set; }
        public string Class { get; set; }
        public int WeaponId { get; set; }
        public Weapon Weapon { get; set; }
        public int LocationId { get; set; }
        public LocationDTO CurrentLocation { get; set; }
        public List<InventoryDTO> Inventory { get; set; }
        public List<CharacterStatDTO> StatSheet { get; set; }
    }
}