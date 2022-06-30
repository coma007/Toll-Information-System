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
            Tollstation oldTollStationModel = _model.EntityToModel(tollStation);
            _repositoryModel.Update(oldTollStationModel);
            _repositoryModel.Save();
        }
    }
}
