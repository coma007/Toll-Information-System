using System;
using System.Collections.Generic;
using System.Text;

namespace TollSystem.Core.Entities
{
    class TollStation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public StationMaster StationMaster { get; set; }
        public List<Referent> Referents { get; set; }
        public List<TollBooth> TollBooths { get; set; }

        public TollStation()
        {

        }

        public TollStation(int id, string name, StationMaster master, List<Referent> referents,
                           List<TollBooth> tollBooths)
        {
            Id = id;
            Name = name;
            StationMaster = master;
            Referents = referents;
            TollBooths = tollBooths;
        }
    }
}
