﻿using System;
using System.Collections.Generic;
using System.Text;
using TollSystem.Core.Enumerations;

namespace TollSystem.Core.Entities
{
    class ScannerEntity : DeviceEntity
    {
        public ScannerType Type;

        public ScannerEntity(ScannerType type)
        {
            Type = type;
        }
    }
}