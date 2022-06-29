using System;
using System.Collections.Generic;
using System.Text;
using TollSystem.Infrastructure.Models;

namespace TollSystem.Core.Entities
{
    public class PrinterEntity : DeviceEntity
    {
        public PrinterEntity(Device device)
        {
            Id = (int)device.Id;
            if (device.Isdamaged == 0)
                IsDamaged = false;
            else
                IsDamaged = true;
        }
    }
}
