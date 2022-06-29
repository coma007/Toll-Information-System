using System;
using System.Collections.Generic;
using System.Text;

namespace TollSystem.Core.Entities
{
    class PricelistEntity
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
    }
}
