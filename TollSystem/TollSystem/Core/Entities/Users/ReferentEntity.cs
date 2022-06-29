using System;
using System.Collections.Generic;
using System.Text;
using TollSystem.Infrastructure.Models;

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

        // flag ('l' - loginUser, 's' - findStationUser)
        public ReferentEntity(Staff s, string flag) : base(s)
        {
            switch (flag)
            {
                case "l":
                    TollStation = new TollStationEntity(s.Station, "l");
                    break;
                case "s":
                    TollStation = null;
                    break;
            }
        }

        public ReferentEntity(Staff s, Tollstation t) : base(s)
        {
            TollStation = new TollStationEntity(s.Station, "l");
        }
    }
}
