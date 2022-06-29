using System;
using System.Collections.Generic;
using System.Text;

namespace TollSystem.Core.Entities
{
    public class DamageEntity
    {
        public string Description { get; set; }
        public int DeviceId { get; set; }

        public DamageEntity()
        { }

        public DamageEntity(string description, int deviceId)
        {
            Description = description;
            DeviceId = deviceId;
        }
    }
}
