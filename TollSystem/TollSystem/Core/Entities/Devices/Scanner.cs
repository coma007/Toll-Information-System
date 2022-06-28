using System;
using System.Collections.Generic;
using System.Text;
using TollSystem.Core.Enumerations;

namespace TollSystem.Core.Entities
{
    class Scanner : Device
    {
        public ScannerType Type;

        public Scanner(ScannerType type)
        {
            Type = type;
        }
    }
}
