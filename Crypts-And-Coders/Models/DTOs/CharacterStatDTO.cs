using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crypts_And_Coders.Models.DTOs
{
    public class CharacterStatDTO
    {
        public int StatId { get; set; }
        public int CharacterId { get; set; }
        public int Level { get; set; }
        public StatDTO Stat { get; set; }
    }
}
