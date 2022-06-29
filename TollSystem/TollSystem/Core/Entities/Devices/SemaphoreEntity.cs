using System;
using System.Collections.Generic;
using System.Text;
using TollSystem.Core.Enumerations;
using TollSystem.Infrastructure.Models;

namespace TollSystem.Core.Entities
{
    public class SemaphoreEntity : DeviceEntity
    {
        public SemaphoreState State { get; set; }

        public SemaphoreEntity()
        {

        }

        public SemaphoreEntity(SemaphoreState state)
        {
            State = state;
        }

        public SemaphoreEntity(Device device)
        {
            Id = (int)device.Id;
            if (device.Isdamaged == 0)
                IsDamaged = false;
            else
                IsDamaged = true;
            State = SemaphoreState.RED;
        }
    }
}
