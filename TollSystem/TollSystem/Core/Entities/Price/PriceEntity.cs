using System;
using System.Collections.Generic;
using System.Text;
using TollSystem.Core.Enumerations;
using TollSystem.Infrastructure.Models;

namespace TollSystem.Core.Entities
{
    public class PriceEntity
    {
        public int OrdinalNumber { get; set; }
        public double PriceEUR { get; set; }
        public int PriceRSD { get; set; }
        public VehicleCategory Category { get; set; }
        public SectionEntity Section { get; set; }

        public PriceEntity()
        { }

        public PriceEntity(double priceEUR, int priceRSD, VehicleCategory category, SectionEntity section)
        {
            PriceEUR = priceEUR;
            PriceRSD = priceRSD;
            Category = category;
            Section = section;
        }

        public PriceEntity(Price price)
        {
            OrdinalNumber = (int)price.Ordinalnumber;
            PriceEUR = (double)price.Priceeur;
            PriceRSD = (int)price.Pricersd;
            Category = (VehicleCategory)Enum.Parse(typeof(VehicleCategory), price.Category);
            //Section = price.Section;
        }
    }
}
