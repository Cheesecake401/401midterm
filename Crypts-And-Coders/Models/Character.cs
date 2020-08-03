using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crypts_And_Coders.Models
{
    public class Character
    {
        public string Name { get; set; }
        public Species Species { get; set; }
        public Class Class { get; set;}
        public int WeaponId { get; set; }
        public int LocationId { get; set; }
        public Weapon Weapon { get; set; }
        public Location CurrentLocation { get; set; }
        public List<CharacterInventory> Inventory { get; set; }

    }

    public enum Species
    {
        Human,
        Elf,
        Gnome,
        Dwarf,
        HalfOrc,
        Dragonborn
    }

    public enum Class
    {
        Paladin,
        Wizard,
        Ranger,
        Thief,
        Bard,
        Cleric,
        Monk,
        Fighter,
        Druid
    }
}
