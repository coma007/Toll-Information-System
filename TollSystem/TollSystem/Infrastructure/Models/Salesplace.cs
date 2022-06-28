using System;
using System.Collections.Generic;

namespace TollSystem.Infrastructure.Models
{
    public partial class Salesplace
    {
        public decimal Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public decimal? Availabletags { get; set; }
        public decimal Isdeleted { get; set; }
    }
}
