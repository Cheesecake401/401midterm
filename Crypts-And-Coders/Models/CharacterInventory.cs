using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crypts_And_Coders.Models
{
    public class CharacterInventory
    {
        public int CharacterId { get; set; }
        public int ItemId { get; set; }

        public Character Character { get; set; }
        public Item Item { get; set; }
    }
}
