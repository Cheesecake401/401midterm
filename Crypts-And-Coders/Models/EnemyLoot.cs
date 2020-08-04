using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crypts_And_Coders.Models
{
    public class EnemyLoot
    {
        public int CharacterId { get; set; }
        public int ItemId { get; set; }

        public Item Item { get; set; }
        public Character Character { get; set; }
    }
}
