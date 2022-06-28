using System;
using System.Collections.Generic;

namespace TollSystem.Infrastructure.Models
{
    public partial class Staff
    {
        public decimal Userid { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public decimal Salary { get; set; }
        public DateTime Validfrom { get; set; }
        public DateTime? Validto { get; set; }
        public string Role { get; set; }
        public decimal? Stationid { get; set; }
        public decimal Isdeleted { get; set; }

        public virtual Tollstation Station { get; set; }
    }
}
