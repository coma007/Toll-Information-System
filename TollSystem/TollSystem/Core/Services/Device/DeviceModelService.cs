using System;
using System.Collections.Generic;
using System.Text;
using TollSystem.Core.Entities;
using TollSystem.Infrastructure.Models;

namespace TollSystem.Core.Services
{
    public class DeviceModelService : IDeviceModelService
    {
        public DeviceEntity ModelToEntity(Device device)
        {
            DeviceEntity deviceEntity = null;
            switch (device.Devicetype)
            {
                case "PRINTER":
                    deviceEntity = new PrinterEntity(device);
                    break;
                case "RAMP":
                    deviceEntity = new RampEntity(device);
                    break;
                case "SEMAPHORE":
                    deviceEntity = new SemaphoreEntity(device);
                    break;
                case "SCANNER":
                    deviceEntity = new ScannerEntity(device);
                    break;
            }
            return deviceEntity;
        }

        public ScannerEntity ModelToEntity(Scanner scanner)
        {
            ScannerEntity scannerEntity = new ScannerEntity(scanner);
            return scannerEntity;
        }
    }
}
