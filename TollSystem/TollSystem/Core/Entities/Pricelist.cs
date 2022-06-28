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
        public Price Price { get; set; }

        public Pricelist()
        { }

        public Pricelist(int id, DateTime validFrom, DateTime validTo, bool isActive, Price price)
        {
            Id = id;
            ValidFrom = validFrom;
            ValidTo = validTo;
            IsActive = isActive;
            Price = price;
        }
    }
}
