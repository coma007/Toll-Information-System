using System;
using System.Collections.Generic;
using System.Text;
using TollSystem.Infrastructure.Models;

namespace TollSystem.Core.Entities
{
    class StationMasterEntity : StaffEntity
    {
        public TollStationEntity TollStation { get; set; }

        public StationMasterEntity()
        {
            
        }

        public StationMasterEntity(TollStationEntity tollStation)
        {
            TollStation = tollStation;
        }

        public StationMasterEntity(Staff s, string flag) : base(s)
        {
            TollStation = null;
            switch (flag)
            {
                case "l":
                    TollStationEntity station = new TollStationEntity(s.Station, "l");
                    TollStation = station;
                    station.StationMaster = this;
                    break;
            }
        }
    }
}
