using System;
using System.Collections.Generic;

namespace TollSystem.Infrastructure.Models
{
    public partial class Tollbooth
    {
        public Tollbooth()
        {
            Device = new HashSet<Device>();
        }

        public decimal Stationid { get; set; }
        public decimal Ordinalnumber { get; set; }
        public decimal Isdeleted { get; set; }

        public virtual Tollstation Station { get; set; }
        public virtual ICollection<Device> Device { get; set; }
    }
}
