using System;
using System.Collections.Generic;
using System.Text;
using TollSystem.Core.Entities;

namespace TollSystem.DesktopHost.ListItems
{
    public class DamagedDeviceListItem
    {
        private readonly string _type;
        private readonly int _boothId;
        private readonly string _description;
        public string Type => _type;
        public int BoothId => _boothId;
        public string Description => _description;


        public DamagedDeviceListItem(int booth, DeviceEntity device, string description)
        {
            _boothId = booth;
            switch (device)
            {
                case PrinterEntity p:
                    _type = "PRINTER";
                    break;
                case RampEntity r:
                    _type = "RAMP";
                    break;
                case ScannerEntity s:
                    _type = "SCANNER FOR " + s.Type;
                    break;
                case SemaphoreEntity s:
                    _type = "SEMAPHORE";
                    break;
                default:
                    _type = "UNKNOWN";
                    break;
            }
            _description = description;
        }

    }
}
