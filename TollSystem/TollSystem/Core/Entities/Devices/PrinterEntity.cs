using System;
using System.Collections.Generic;
using System.Text;

namespace TollSystem.Core.Entities
{
    public class PrinterEntity : DeviceEntity
    {
        public PrinterEntity(int id, bool isDamaged)
        {
            Id = id;
            IsDamaged = isDamaged;
        }
    }
}
