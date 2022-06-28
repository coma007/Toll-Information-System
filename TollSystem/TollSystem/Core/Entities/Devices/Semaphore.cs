using System;
using System.Collections.Generic;
using System.Text;
using TollSystem.Core.Enumerations;

namespace TollSystem.Core.Entities
{
    class Semaphore : Device
    {
        public SemaphoreState State { get; set; }

        public Semaphore()
        {

        }

        public Semaphore(SemaphoreState state)
        {
            State = state;
        }
    }
}
