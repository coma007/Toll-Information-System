using System;
using System.Collections.Generic;

namespace TollSystem.Infrastructure.Models
{
    public partial class Pricelist
    {
        public Pricelist()
        {
            Price = new HashSet<Price>();
        }

        public decimal Id { get; set; }
        public DateTime Validfrom { get; set; }
        public DateTime? Validto { get; set; }
        public decimal? Isactive { get; set; }
        public decimal Isdeleted { get; set; }

        public virtual ICollection<Price> Price { get; set; }
    }
}
