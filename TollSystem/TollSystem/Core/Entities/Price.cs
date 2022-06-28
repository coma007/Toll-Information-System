using System;
using System.Collections.Generic;
using System.Text;
using TollSystem.Core.Enumerations;

namespace TollSystem.Core.Entities
{
    class Price
    {
        public int PriceEUR { get; set; }
        public int PriceRSD { get; set; }
        public VehicleCategory Category { get; set; }
        public Tag Tag { get; set; }
        public Section Section { get; set; }

        public Price()
        { }

        public Price(int priceEUR, int priceRSD, VehicleCategory category, Tag tag, Section section)
        {
            PriceEUR = priceEUR;
            PriceRSD = priceRSD;
            Category = category;
            Tag = tag;
            Section = section;
        }
    }
}
