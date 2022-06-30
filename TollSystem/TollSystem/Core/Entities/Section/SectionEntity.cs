using System;
using System.Collections.Generic;
using System.Text;
using TollSystem.Core.Services;
using TollSystem.Infrastructure.Models;
using TollSystem.Infrastructure.Repositories;

namespace TollSystem.Core.Entities
{
    public class SectionEntity
    {
        public int Id { get; set; }
        public double Length { get; set; }
        public TollStationEntity EntranceTollStation { get; set; }
        public TollStationEntity ExitTollStation { get; set; }

        public SectionEntity()
        { 
        }

        public SectionEntity(int id, double length, TollStationEntity entranceTollStation, 
                             TollStationEntity exitTollStation)
        {
            Id = id;
            Length = length;
            EntranceTollStation = entranceTollStation;
            ExitTollStation = exitTollStation;
        }

        public SectionEntity(Section section, TollStationEntity tollstation1, TollStationEntity tollstation2)
        {
            Id = (int)section.Id;
            Length = (double)section.Length;
            EntranceTollStation = tollstation1;
            ExitTollStation = tollstation2;
        }
    }
}
