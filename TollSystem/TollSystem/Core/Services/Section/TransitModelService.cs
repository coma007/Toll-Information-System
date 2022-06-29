﻿using System;
using System.Collections.Generic;
using System.Text;
using TollSystem.Core.Entities;
using TollSystem.Core.Services;
using TollSystem.Infrastructure.Models;

namespace TollSystem.Core.Services
{
    class TransitModelService : ITransitModelService
    {
        public TransitEntity ModelToEntity(Transit transit, ITollBoothRepositoryService service, TollBoothModelService tollBoothModel,
            IDeviceRepositoryService repository, IRepositoryService<TollStationEntity> repo)
        {
            TransitEntity transitEntity = new TransitEntity(transit);
            Tollbooth tollboothEntrance = service.FindByStationIdAndOrdinalNumber((int)transit.Entrancestationid, (int)transit.Entrancestationboothid);
            transitEntity.EntranceTollBooth = tollBoothModel.ModelToEntity(tollboothEntrance, repository, repo);

            Tollbooth tollboothExit = service.FindByStationIdAndOrdinalNumber((int)transit.Exitstationid, (int)transit.Exitstationboothid);
            transitEntity.ExitTollBooth = tollBoothModel.ModelToEntity(tollboothEntrance, repository, repo);

            return transitEntity;
        }

    }
}
