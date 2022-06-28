using System;
using System.Collections.Generic;
using System.Text;

namespace TollSystem.Core.Entities
{
    class Section
    {
        public double Length { get; set; }
        // TODO dodati tollstation

        public Section()
        { 
        }

        public Section(double length)
        {
            Length = length;
        }
    }
}
