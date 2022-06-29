using System;
using System.Collections.Generic;
using System.Text;
using TollSystem.Core.Entities;

namespace TollSystem.Core.Services.Tolls
{
    public class UpdateTollStationService
    {
        private IRepositoryService<TollStationEntity> _repository;
        public UpdateTollStationService(IRepositoryService<TollStationEntity> repository)
        {
            _repository = repository;
        }

        public void UpdateTollStation(TollStationEntity tollStation)
        {
            TollStationEntity oldTollStation = _repository.GetById(tollStation.Id);
            oldTollStation.Name = tollStation.Name;
            oldTollStation.StationMaster = tollStation.StationMaster;
            oldTollStation.Referents = tollStation.Referents;
            _repository.Update(oldTollStation);
            _repository.Save();
        }
    }
}
