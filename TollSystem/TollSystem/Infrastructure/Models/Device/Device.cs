using System;
using System.Collections.Generic;

namespace TollSystem.Infrastructure.Models
{
    public partial class Device
    {
        public decimal Id { get; set; }
        public decimal? Isdamaged { get; set; }
        public string Devicetype { get; set; }
        public decimal Tollboothnumber { get; set; }
        public decimal Stationid { get; set; }
        public decimal Isdeleted { get; set; }

        public virtual Tollbooth Tollbooth { get; set; }
        public virtual Damage Damage { get; set; }
        public virtual Scanner Scanner { get; set; }
    }
}
