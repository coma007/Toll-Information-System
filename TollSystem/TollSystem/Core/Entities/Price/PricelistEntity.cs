using System;
using System.Collections.Generic;
using System.Text;
using TollSystem.Infrastructure.Models;

namespace TollSystem.Core.Entities
{
    public class PricelistEntity
    {
        public int Id { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public bool IsActive { get; set; }
        public List<PriceEntity> Prices { get; set; }

        public PricelistEntity()
        { }

        public PricelistEntity(int id, DateTime validFrom, DateTime validTo, bool isActive, List<PriceEntity> prices)
        {
            Id = id;
            ValidFrom = validFrom;
            ValidTo = validTo;
            IsActive = isActive;
            Prices = prices;
        }

        public PricelistEntity(Pricelist pricelist)
        {
            Id = (int)pricelist.Id;
            ValidFrom = pricelist.Validfrom;
            ValidTo = (DateTime)pricelist.Validto;
            IsActive = false;
            if (pricelist.Isactive == 1) IsActive = true;
        }
    }
}
