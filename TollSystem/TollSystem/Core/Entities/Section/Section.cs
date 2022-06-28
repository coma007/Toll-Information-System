using System;
using System.Collections.Generic;
using System.Text;

namespace TollSystem.Core.Entities
{
    class Section
    {
        public double Length { get; set; }
        public TollStation EntranceTollStation { get; set; }
        public TollStation ExitTollStation { get; set; }

        public Section()
        { 
        }

        public Section(double length, TollStation entranceTollStation, 
                       TollStation exitTollStation)
        {
            Length = length;
            EntranceTollStation = entranceTollStation;
            ExitTollStation = exitTollStation;
        }
    }
}
