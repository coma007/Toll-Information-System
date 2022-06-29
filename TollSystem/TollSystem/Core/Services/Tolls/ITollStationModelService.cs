using System;
using System.Collections.Generic;
using System.Text;
using TollSystem.Core.Entities;
using TollSystem.Infrastructure.Models;

namespace TollSystem.Core.Services
{
    public interface ITollStationModelService
    {
        public Tollstation EntityToModel(TollStationEntity entity);
        public TollStationEntity ModelToEntity(Tollstation station);
    }
}
