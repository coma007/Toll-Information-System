using System;
using System.Collections.Generic;
using System.Text;

namespace TollSystem.Core.Entities
{
    class Pricelist
    {
        public int Id { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public bool IsActive { get; set; }
        public List<Price> Prices { get; set; }

        public Pricelist()
        { }

        public Pricelist(int id, DateTime validFrom, DateTime validTo, bool isActive, List<Price> prices)
        {
            Id = id;
            ValidFrom = validFrom;
            ValidTo = validTo;
            IsActive = isActive;
            Prices = prices;
        }
    }
}
