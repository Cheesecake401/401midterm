using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crypts_And_Coders.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }

        public List<EnemyLoot> EnemyLoot { get; set; }


    }
}
