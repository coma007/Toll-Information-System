using System;
using System.Collections.Generic;
using System.Text;
using TollSystem.Core.Enumerations;
using TollSystem.Infrastructure.Models;

namespace TollSystem.Core.Entities
{
    public class RampEntity : DeviceEntity
    {
        public RampState State;

        public RampEntity()
        {

        }

        public RampEntity(RampState state)
        {
            State = state;
        }

        public RampEntity(Device device)
        {
            Id = (int)device.Id;
            if (device.Isdamaged == 0)
                IsDamaged = false;
            else
                IsDamaged = true;
            State = RampState.CLOSED;
        }
    }
}
