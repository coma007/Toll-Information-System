using System;
using System.Collections.Generic;
using System.Text;

namespace TollSystem.Core.Entities
{
    class Device
    {
        public int Id { get; set; }
        public bool IsDamaged { get; set; }

        public Device()
        {

        }

        public Device(int id, bool isDamaged)
        {
            Id = id;
            IsDamaged = isDamaged;
        }
    }
}
