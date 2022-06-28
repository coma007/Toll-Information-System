using System;
using System.Collections.Generic;
using System.Text;

namespace TollSystem.Core.Entities
{
    class StationMaster : Staff
    {
        public TollStation TollStation { get; set; }

        public StationMaster()
        {
            
        }

        public StationMaster(TollStation tollStation)
        {
            TollStation = tollStation;
        }
    }
}
