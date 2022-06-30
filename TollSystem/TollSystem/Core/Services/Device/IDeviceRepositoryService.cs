using System;
using System.Collections.Generic;
using System.Text;
using TollSystem.Infrastructure.Models;

namespace TollSystem.Core.Services
{
    public interface IDeviceRepositoryService : IRepositoryService<Device>
    {
        public List<Device> FindByTollBooth(int stationId, int tollBoothNumber);
    }
}
