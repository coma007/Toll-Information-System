using System;
using System.Collections.Generic;
using System.Text;
using TollSystem.Infrastructure.Models;

namespace TollSystem.Infrastructure.Repositories
{
    public interface IDeviceRepository : IRepository<Device>
    {
        public List<Device> FindByTollBooth(int stationId, int tollBoothNumber);
    }
}
