using System;
using System.Collections.Generic;
using System.Text;

namespace TollSystem.Core.Entities
{
    class Damage
    {
        public string Description { get; set; }
        public int DeviceId { get; set; }

        public Damage()
        { }

        public Damage(string description, int deviceId)
        {
            Description = description;
            DeviceId = deviceId;
        }
    }
}
