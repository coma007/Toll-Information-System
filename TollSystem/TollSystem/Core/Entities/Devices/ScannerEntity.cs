using System;
using System.Collections.Generic;
using System.Text;
using TollSystem.Core.Enumerations;
using TollSystem.Infrastructure.Models;

namespace TollSystem.Core.Entities
{
    public class ScannerEntity : DeviceEntity
    {
        public ScannerType Type;
        public bool IsDeleted { get; set; }

        public ScannerEntity()
        { }

        public ScannerEntity(ScannerType type)
        {
            Type = type;
        }

        public ScannerEntity(Device device)
        {
            Id = (int)device.Id;
            if (device.Isdeleted == 1)
                IsDeleted = true;
            else
                IsDeleted = false;
        }

        public ScannerEntity(Scanner scanner)
        { 
            Id = (int)scanner.Id;
            if (scanner.Isdeleted == 1)
                IsDeleted = true;
            else
                IsDeleted = false;
            Type = (ScannerType) Enum.Parse(typeof(ScannerType), scanner.Scannertype, true); 
        }
    }
}
