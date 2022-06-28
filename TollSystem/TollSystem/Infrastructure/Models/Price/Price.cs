using System;
using System.Collections.Generic;

namespace TollSystem.Infrastructure.Models
{
    public partial class Price
    {
        public decimal Pricelistid { get; set; }
        public decimal Ordinalnumber { get; set; }
        public string Category { get; set; }
        public decimal? Sectionid { get; set; }
        public decimal Pricersd { get; set; }
        public decimal Priceeur { get; set; }
        public decimal Isdeleted { get; set; }

        public virtual Pricelist Pricelist { get; set; }
        public virtual Section Section { get; set; }
    }
}
