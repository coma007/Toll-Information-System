using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TollSystem.Infrastructure.Models;

namespace TollSystem.Infrastructure.Repositories
{
    public class DeviceRepository : Repository<Device>, IDeviceRepository
    {
        public DeviceRepository(ModelContext context) : base(context, context.Device)
        {
        }

        public List<Device> FindByTollBooth(int stationId, int tollBoothNumber)
        {
            return _table.Where(d => d.Stationid == stationId && d.Tollboothnumber == tollBoothNumber)
                         .ToList();
        }
    }
}
