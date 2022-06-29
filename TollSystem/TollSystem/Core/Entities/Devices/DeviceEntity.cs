using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
