using System;
using System.Collections.Generic;
using System.Text;
using TollSystem.Core.Entities;
using TollSystem.Infrastructure.Models;

namespace TollSystem.Core.Services
{
    class FindDamageDevice
    {
        private IDeviceRepositoryService _deviceService;
        private IDamageRepositoryService _damageService;
        private IRepositoryService<Scanner> _scannerService;

        public FindDamageDevice(IDeviceRepositoryService deviceService, IDamageRepositoryService damageService,
            IRepositoryService<Scanner> scannerService)
        {
            _deviceService = deviceService;
            _damageService = damageService;
            _scannerService = scannerService;
        }

        public Dictionary<int, Dictionary<DeviceEntity, string>> FindTollBothWithDamageDevices()
        {
            Dictionary<DeviceEntity, string> damages = new Dictionary<DeviceEntity, string>();
            Dictionary<int, Dictionary<DeviceEntity, string>> allDamageDevices = new Dictionary<int, Dictionary<DeviceEntity, string>>();
       
            foreach (TollBoothEntity tollBooth in SystemCurrentData.CurrentStation.TollBooths)
            {
                if (tollBooth.RecieptPrinter.IsDamaged)
                {
                    Damage damageDevice = _damageService.FindByDeviceId(tollBooth.RecieptPrinter.Id);
                    damages.Add(tollBooth.RecieptPrinter, damageDevice.Description);
                }
                else if (tollBooth.TicketPrinter.IsDamaged)
                {
                    Damage damageDevice = _damageService.FindByDeviceId(tollBooth.TicketPrinter.Id);
                    damages.Add(tollBooth.TicketPrinter, damageDevice.Description);
                }
                else if (tollBooth.Semaphore.IsDamaged)
                {
                    Damage damageDevice = _damageService.FindByDeviceId(tollBooth.Semaphore.Id);
                    damages.Add(tollBooth.Semaphore, damageDevice.Description);
                }
                else if (tollBooth.Ramp.IsDamaged)
                {
                    Damage damageDevice = _damageService.FindByDeviceId(tollBooth.Ramp.Id);
                    damages.Add(tollBooth.Ramp, damageDevice.Description);
                }
                else if (tollBooth.TagScanner.IsDamaged)
                {
                    Damage damageDevice = _damageService.FindByDeviceId(tollBooth.TagScanner.Id);
                    damages.Add(tollBooth.TagScanner, damageDevice.Description);
                }
                else if (tollBooth.LicensePlateScanner.IsDamaged)
                {
                    Damage damageDevice = _damageService.FindByDeviceId(tollBooth.LicensePlateScanner.Id);
                    damages.Add(tollBooth.LicensePlateScanner, damageDevice.Description);
                }

                if (damages.Count != 0)
                    allDamageDevices.Add(tollBooth.OrdinalNumber, damages);
            }
            return allDamageDevices;
        }

        public void RepairDevice(DeviceEntity damageDeviceEntity)
        {
            Device device = _deviceService.GetById(damageDeviceEntity.Id);
            device.Isdamaged = 0;
            _deviceService.Update(device);
            _deviceService.Save();

            Damage damage = _damageService.GetById(damageDeviceEntity.Id);
            _damageService.Delete(damage);
            _damageService.Save();

            //if (damageDeviceEntity is ScannerEntity s)
            //{
            //    Scanner scanner = _scannerService.GetById(damageDeviceEntity);
            //    scanner.Isdamaged = 0;
            //    _scannerService.Update(scanner);
            //    _scannerService.Save();
            //}
        }

        public void ReportDamage(string type, string description)
        {
            Device device = new Device();
            Damage damage = new Damage();

            if (type.Equals("PRINTER"))
            {
                PrinterEntity printer = SystemCurrentData.CurrentTollBooth.TicketPrinter;
                device = _deviceService.GetById(printer.Id);
                damage.Deviceid = printer.Id;    
            }
            else if (type.Equals("RAMP"))
            {
                RampEntity ramp = SystemCurrentData.CurrentTollBooth.Ramp;
                device = _deviceService.GetById(ramp.Id);
                damage.Deviceid = ramp.Id;
            }
            else if (type.Equals("SEMAPHORE"))
            {
                SemaphoreEntity semaphore = SystemCurrentData.CurrentTollBooth.Semaphore;
                device = _deviceService.GetById(semaphore.Id);
                damage.Deviceid = semaphore.Id;
            }
            else if (type.Equals("SCANNER_LICENCE_PLATE"))
            {
                ScannerEntity scanner = SystemCurrentData.CurrentTollBooth.LicensePlateScanner;
                device = _deviceService.GetById(scanner.Id);
                damage.Deviceid = scanner.Id;
            }
            else if (type.Equals("SCANNER_TAG"))
            {
                ScannerEntity scanner = SystemCurrentData.CurrentTollBooth.TagScanner;
                device = _deviceService.GetById(scanner.Id);
                damage.Deviceid = scanner.Id;
            }
            device.Isdamaged = 1;
            _deviceService.Update(device);
            _deviceService.Save();

            damage.Description = description;
            damage.Isdeleted = 0;
            _damageService.Add(damage);
            _damageService.Save();
        }
    }
}
