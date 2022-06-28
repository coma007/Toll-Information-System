using System;
using System.Collections.Generic;
using System.Text;
using TollSystem.Core.Enumerations;

namespace TollSystem.Core.Entities
{
    class RampEntity : DeviceEntity
    {
        public RampState State;

        public RampEntity()
        {

        }

        public RampEntity(RampState state)
        {
            State = state;
        }
    }
}
