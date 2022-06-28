using System;
using System.Collections.Generic;

namespace TollSystem.Infrastructure.Models
{
    public partial class Tollstation
    {
        public Tollstation()
        {
            SectionTollstation1 = new HashSet<Section>();
            SectionTollstation2 = new HashSet<Section>();
            Staff = new HashSet<Staff>();
            Tollbooth = new HashSet<Tollbooth>();
        }

        public decimal Id { get; set; }
        public string Name { get; set; }
        public decimal Isdeleted { get; set; }

        public virtual ICollection<Section> SectionTollstation1 { get; set; }
        public virtual ICollection<Section> SectionTollstation2 { get; set; }
        public virtual ICollection<Staff> Staff { get; set; }
        public virtual ICollection<Tollbooth> Tollbooth { get; set; }
    }
}
