using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crypts_And_Coders.Models
{
    public class CharacterStat
    {
        public int StatId { get; set; }
        public int CharacterId { get; set; }
        public int Level { get; set; }
        public Character Character { get; set; }
        public Stat Stat { get; set; }
    }
}
