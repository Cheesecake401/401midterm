using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crypts_And_Coders.Models
{
    public class SpeciesAndClass
    {
        public enum Species
        {
            Human,
            Elf,
            Gnome,
            Dwarf,
            HalfOrc,
            Dragonborn,
            Goblin,
            Troll,
            Dragon,
            Harpy,
            Undead,
            Minotaur
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
            Druid,
            Archer,
            Swordsman
        }
    }
}