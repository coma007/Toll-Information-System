using System;
using System.Collections.Generic;
using System.Text;
using TollSystem.Infrastructure.Models;

namespace TollSystem.Core.Entities
{
    public class DeviceEntity
    {
        public int Id { get; set; }
        public bool IsDamaged { get; set; }

        public DeviceEntity()
        {

        }

        public DeviceEntity(int id, bool isDamaged)
        {
            Id = id;
            IsDamaged = isDamaged;
        }

        public DeviceEntity(Device device)
        {
            Id = (int)device.Id;
            if (device.Isdamaged == 0)
                IsDamaged = false;
            else
                IsDamaged = true;
        }
    }
}
