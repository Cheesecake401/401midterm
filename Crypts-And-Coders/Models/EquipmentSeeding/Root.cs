using System.Collections.Generic;

namespace Crypts_And_Coders.Models.EquipmentSeeding
{
    public class Root
    {
        public string _id { get; set; }
        public string index { get; set; }
        public string name { get; set; }
        public object equipment_category { get; set; }
        public string weapon_category { get; set; }
        public string weapon_range { get; set; }
        public string category_range { get; set; }
        public Cost cost { get; set; }
        public Damage damage { get; set; }
        public Range range { get; set; }
        public decimal weight { get; set; }
        public List<Property> properties { get; set; }
        public string url { get; set; }
    }
}