using System;
using System.Collections.Generic;

namespace TollSystem.Infrastructure.Models
{
    public partial class Policereport
    {
        public decimal Id { get; set; }
        public string Licenseplate { get; set; }
        public DateTime Reportdate { get; set; }
        public decimal Speed { get; set; }
    }
}
