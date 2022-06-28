using System;
using System.Collections.Generic;

namespace TollSystem.Infrastructure.Models
{
    public partial class Pricelist
    {
        public decimal Id { get; set; }
        public DateTime Validfrom { get; set; }
        public DateTime? Validto { get; set; }
        public decimal? Isactive { get; set; }
        public decimal Isdeleted { get; set; }
    }
}
