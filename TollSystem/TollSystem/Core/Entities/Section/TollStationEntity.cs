using System;
using System.Collections.Generic;
using System.Text;

namespace TollSystem.Core.Entities
{
    class TollStationEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public StationMasterEntity StationMaster { get; set; }
        public List<ReferentEntity> Referents { get; set; }
        public List<TollBoothEntity> TollBooths { get; set; }

        public TollStationEntity()
        {

        }

        public TollStationEntity(int id, string name, StationMasterEntity master, List<ReferentEntity> referents,
                           List<TollBoothEntity> tollBooths)
        {
            Id = id;
            Name = name;
            StationMaster = master;
            Referents = referents;
            TollBooths = tollBooths;
        }
    }
}
