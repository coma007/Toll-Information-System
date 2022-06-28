using System;
using System.Collections.Generic;
using System.Text;
using TollSystem.Core.Enumerations;

namespace TollSystem.Core.Entities
{
    class Ramp : Device
    {
        public RampState State;

        public Ramp()
        {

        }

        public Ramp(RampState state)
        {
            State = state;
        }
    }
}
