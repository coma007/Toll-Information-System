using System;
using System.Collections.Generic;
using System.Text;
using TollSystem.Core.Entities;
using TollSystem.Infrastructure.Models;
using TollSystem.Infrastructure.Repositories;

namespace TollSystem.Core.Services
{

    class DeviceRepositoryService : RepositoryService<Device>, IDeviceRepositoryService
    {
        public DeviceRepositoryService(IRepository<Device> repository) : base(repository)
        {

        }
    }
}
