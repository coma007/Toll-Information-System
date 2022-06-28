using System;
using System.Collections.Generic;

namespace TollSystem.Infrastructure.Models
{
    public partial class Section
    {
        public decimal Id { get; set; }
        public decimal Length { get; set; }
        public decimal Tollstation1id { get; set; }
        public decimal Tollstation2id { get; set; }
        public decimal Isdeleted { get; set; }

        public virtual Tollstation Tollstation1 { get; set; }
        public virtual Tollstation Tollstation2 { get; set; }
    }
}
