using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
