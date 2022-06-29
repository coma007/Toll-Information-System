using System;
using System.Collections.Generic;
using System.Text;
using TollSystem.Core.Entities;
using TollSystem.Infrastructure.Models;
using TollSystem.Infrastructure.Repositories;

namespace TollSystem.Core.Services
{

    public class DeviceRepositoryService : RepositoryService<Device>, IDeviceRepositoryService
    {
        private IDeviceRepository _repository;

        public DeviceRepositoryService(IRepository<Device> repository) : base(repository)
        {

        }

        public List<Device> FindByTollBooth(int stationId, int tollBoothNumber)
        {
            return _repository.FindByTollBooth(stationId, tollBoothNumber);
        }
    }
}
