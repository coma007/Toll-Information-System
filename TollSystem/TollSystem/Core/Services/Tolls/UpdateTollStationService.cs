using System;
using System.Collections.Generic;
using System.Text;
using TollSystem.Core.Entities;
using TollSystem.Infrastructure.Models;

namespace TollSystem.Core.Services
{
    public class UpdateTollStationService : IUpdateTollStationService
    {
        private ITollStationRepositoryService _repositoryModel;
        private ITollStationModelService _model;
        public UpdateTollStationService(ITollStationRepositoryService repositoryModel,
                                        ITollStationModelService model)
        {
            _repositoryModel = repositoryModel;
            _model = model;
        }

        public void UpdateTollStation(TollStationEntity tollStation)
        {
            Tollstation station = _repositoryModel.FindById(tollStation.Id);
            station.Name = tollStation.Name;
            _repositoryModel.Update(station);
            _repositoryModel.Save();
        }
    }
}
