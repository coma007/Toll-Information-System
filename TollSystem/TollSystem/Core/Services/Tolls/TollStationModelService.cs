using System;
using System.Collections.Generic;
using System.Text;
using TollSystem.Core.Entities;
using TollSystem.Infrastructure.Models;

namespace TollSystem.Core.Services
{
    public class TollStationModelService : ITollStationModelService
    {
        public Tollstation EntityToModel(TollStationEntity entity)
        {
            Tollstation station = new Tollstation();
            station.Id = entity.Id;
            station.Name = entity.Name;
            station.Isdeleted = 0;
            return station;
        }

        public TollStationEntity ModelToEntity(Tollstation station)
        {
            return new TollStationEntity(station, "l");
        }
    }
}
