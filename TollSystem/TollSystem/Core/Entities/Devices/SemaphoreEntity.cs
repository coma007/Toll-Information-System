using System;
using System.Collections.Generic;
using System.Text;
using TollSystem.Core.Enumerations;

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
    }
}
