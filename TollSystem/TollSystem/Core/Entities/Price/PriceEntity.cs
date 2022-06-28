using System;
using System.Collections.Generic;
using System.Text;
using TollSystem.Core.Enumerations;

namespace TollSystem.Core.Entities
{
    class PriceEntity
    {
        public int PriceEUR { get; set; }
        public int PriceRSD { get; set; }
        public VehicleCategory Category { get; set; }
        public SectionEntity Section { get; set; }

        public PriceEntity()
        { }

        public PriceEntity(int priceEUR, int priceRSD, VehicleCategory category, SectionEntity section)
        {
            PriceEUR = priceEUR;
            PriceRSD = priceRSD;
            Category = category;
            Section = section;
        }
    }
}
