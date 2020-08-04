using Crypts_And_Coders.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crypts_And_Coders.Models
{
    public class Stat
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<CharacterStat> StatSheet { get; set; }
    }
}
