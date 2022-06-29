using System;
using System.Collections.Generic;
using System.Text;
using TollSystem.Core.Entities;
using TollSystem.Infrastructure.Models;

namespace TollSystem.Core.Services.Tolls
{
    public class DeleteTollStationService
    {
        private ITollStationRepositoryService _repository;
        private ITollStationModelService _model;

        public DeleteTollStationService(ITollStationRepositoryService repository,
                                        ITollStationModelService model)
        {
            _repository = repository;
            _model = model;
        }

        public DeleteTollStationService(TollStationEntity tollStation)
        {
            Tollstation station = _model.EntityToModel(tollStation);
            station.Isdeleted = 1;
            _repository.Update(station);
            _repository.Save();
        }
    }
}
