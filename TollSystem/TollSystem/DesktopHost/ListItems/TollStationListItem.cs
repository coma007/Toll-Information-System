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
        public StaffEntity StationMaster => _station.StationMaster;
        public int BoothsNumber => _station.TollBooths.Count;

        public TollStationListItem(TollStationEntity station)
        {
            _station = station;
        }
    }
}