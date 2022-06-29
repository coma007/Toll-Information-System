using System;
using System.Collections.Generic;
using System.Text;
using TollSystem.Core.Entities;

namespace TollSystem.Core.Services
{
    public interface IDeleteTollStationService
    {
        public void DeleteTollStation(TollStationEntity tollStation);
    }
}
