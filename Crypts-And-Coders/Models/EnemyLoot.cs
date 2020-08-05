using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crypts_And_Coders.Models
{
    public class EnemyLoot
    {
        public int EnemyId { get; set; }
        public int ItemId { get; set; }

        public Item Item { get; set; }
        public Enemy Enemy { get; set; }
    }
}
