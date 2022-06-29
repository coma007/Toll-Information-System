using System;
using System.Collections.Generic;
using System.Text;
using TollSystem.Infrastructure.Models;

namespace TollSystem.Core.Entities
{
    public class TollStationEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public StationMasterEntity StationMaster { get; set; }
        public List<ReferentEntity> Referents { get; set; }
        public List<TollBoothEntity> TollBooths { get; set; }

        public TollStationEntity()
        {
            Referents = new List<ReferentEntity>();
            TollBooths = new List<TollBoothEntity>();
        }

        public TollStationEntity(int id, string name, StationMasterEntity master, List<ReferentEntity> referents,
                           List<TollBoothEntity> tollBooths) : base()
        {
            Id = id;
            Name = name;
            StationMaster = master;
            Referents = referents;
            TollBooths = tollBooths;
        }

        //flag ('l' - loginUser, 'c'-stationCreation)
        public TollStationEntity(Tollstation station, string flag)
        {
            Id = (int)station.Id;
            Name = station.Name;
            switch (flag)
            {
                case "l":
                    TollBooths = null;
                    Referents = null;
                    StationMaster = null;
                    break;
                case "c":
                    // promeni ovo
                    TollBooths = null;
                    Referents = null;
                    StationMaster = null;
                    break;
            }
        }
    }
}
