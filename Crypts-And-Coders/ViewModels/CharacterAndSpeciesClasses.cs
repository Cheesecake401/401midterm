using Crypts_And_Coders.Models;
using Crypts_And_Coders.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Crypts_And_Coders.Models.SpeciesAndClass;

namespace Crypts_And_Coders.ViewModels
{
    public class CharacterAndSpeciesClasses
    {
        public CharacterDTO CharacterDTO { get; set; }

        //public Species Species { get; set; }
        //public Class Class { get; set; }
        public SpeciesAndClass SpeciesAndClass { get; set; }
    }
}