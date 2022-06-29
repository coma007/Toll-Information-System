using System;
using System.Collections.Generic;

namespace TollSystem.Infrastructure.Models
{
    public partial class Transaction
    {
        public decimal Id { get; set; }
        public decimal Transitid { get; set; }
        public decimal Price { get; set; }
        public string Currency { get; set; }
        public decimal Isdeleted { get; set; }

        public virtual Transit Transit { get; set; }
    }
}
