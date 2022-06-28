using System;
using System.Collections.Generic;

namespace TollSystem.Infrastructure.Models
{
    public partial class Tag
    {
        public Tag()
        {
            Transit = new HashSet<Transit>();
        }

        public decimal Id { get; set; }
        public decimal Currentbalance { get; set; }
        public string Category { get; set; }
        public string Licenseplate { get; set; }
        public DateTime? Expirationdate { get; set; }
        public decimal Isdeleted { get; set; }

        public virtual ICollection<Transit> Transit { get; set; }
    }
}
