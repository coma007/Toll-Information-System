using System;
using System.Collections.Generic;
using System.Text;
using TollSystem.Core.Entities;
using TollSystem.Infrastructure.Models;

namespace TollSystem.Core.Services
{
    public interface ITollBoothModel
    {
        public TollBoothEntity ModelToEntity(Tollbooth tollbooth, IDeviceRepositoryService repository,
                                             IRepositoryService<TollStationEntity> repo);
    }
}
