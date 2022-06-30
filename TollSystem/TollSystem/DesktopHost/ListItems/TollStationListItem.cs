using System;
using System.Collections.Generic;
using System.Text;
using TollSystem.Core.Entities;
using TollSystem.DesktopHost.Controllers;

namespace TollSystem.DesktopHost.ListItems
{
    public class TollStationListItem
    {
        private readonly TollStationEntity _station;
        public TollStationEntity Station { get => _station; }

        public string Name => _station.Name;
        public StaffEntity StationMaster { get; set; }
        public int BoothsNumber { get; set; }

        public TollStationListItem(TollStationEntity station)
        {
            _station = station;
        }
    }
}