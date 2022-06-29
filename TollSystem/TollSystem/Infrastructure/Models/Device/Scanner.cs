using System;
using System.Collections.Generic;

namespace TollSystem.Infrastructure.Models
{
    public partial class Scanner
    {
        public decimal Id { get; set; }
        public string Scannertype { get; set; }
        public decimal Isdeleted { get; set; }
        public virtual Device IdNavigation { get; set; }
    }
}
