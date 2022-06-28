using System;
using System.Collections.Generic;

namespace TollSystem.Infrastructure.Models
{
    public partial class Damage
    {
        public decimal Deviceid { get; set; }
        public string Description { get; set; }
        public decimal Isdeleted { get; set; }

        public virtual Device Device { get; set; }
    }
}
