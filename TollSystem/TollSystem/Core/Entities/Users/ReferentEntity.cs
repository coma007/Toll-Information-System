using System;
using System.Collections.Generic;
using System.Text;

namespace TollSystem.Core.Entities
{
    class ReferentEntity : StaffEntity
    {
        public TollStationEntity TollStation { get; set; }

        public ReferentEntity()
        {

        }

        public ReferentEntity(TollStationEntity tollStation)
        {
            TollStation = tollStation;
        }
    }
}
