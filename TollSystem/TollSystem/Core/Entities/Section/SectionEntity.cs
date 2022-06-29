using System;
using System.Collections.Generic;
using System.Text;

namespace TollSystem.Core.Entities
{
    class SectionEntity
    {
        public double Length { get; set; }
        public TollStationEntity EntranceTollStation { get; set; }
        public TollStationEntity ExitTollStation { get; set; }

        public SectionEntity()
        { 
        }

        public SectionEntity(double length, TollStationEntity entranceTollStation, 
                       TollStationEntity exitTollStation)
        {
            Length = length;
            EntranceTollStation = entranceTollStation;
            ExitTollStation = exitTollStation;
        }
    }
}
