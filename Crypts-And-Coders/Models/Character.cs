using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crypts_And_Coders.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int WeaponId { get; set; }
        public int LocationId { get; set; }
        public SpeciesAndClass.Species Species { get; set; }
        public SpeciesAndClass.Class Class { get; set; }
        public Weapon Weapon { get; set; }
        public Location CurrentLocation { get; set; }
        public List<CharacterInventory> Inventory { get; set; }
        public List<CharacterStat> StatSheet { get; set; }
        public List<EnemyLoot> EnemyLoot { get; set; }

    }
}