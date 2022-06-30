using System.Collections.Generic;
using TollSystem.Core.Entities;
using TollSystem.Core.Services;
using TollSystem.DesktopHost.Controllers;
using TollSystem.Infrastructure.Models;
using TollSystem.Infrastructure.Repositories;

namespace TollSystem.Commands
{
    public class RepairDeviceCommand : BaseCommand
    {
        private DamagesViewModel _model;
        private IDeviceRepositoryService _device = ServiceContainer.DeviceRepositoryService;
        private IDamageRepositoryService _damage = ServiceContainer.DamageRepositoryService;
        private IRepository<Scanner> _scanner = RepositoryContainer.ScannerRepository;

        public RepairDeviceCommand(DamagesViewModel m)
        {
            _model = m;
        }


        public override void Execute(object parameter)
        {
            List<Device> devices = _device.FindByTollBooth(SystemCurrentData.CurrentStation.Id, _model.SelectedDevice.BoothId);

            string type = null;
            string scannerType = null;
            switch (_model.SelectedDevice.Type)
            {
                case "SEMAPHORE":
                    type = "SEMAPHORE";
                    break;
                case "RAMP":
                    type = "RAMP";
                    break;
                case "PRINTER":
                    type = "PRINTER";
                    break;
                case "SCANNER FOR TAG":
                    type = "SCANNER";
                    scannerType = "TAG";
                    break;
                case "SCANNER FOR LICENSE PLATES":
                    type = "SCANNER";
                    scannerType = "LICENCE_PLATE";
                    break;
            }

            foreach (Device d in devices)
            {
                if (d.Devicetype.Equals(type))
                {
                    if (type.Equals("SCANNER"))
                    {
                        Scanner scanner = _scanner.GetById(d.Id);
                        if (!scanner.Scannertype.Equals(scannerType))
                        {
                            continue;
                        }
                    }

                    d.Isdamaged = 0;
                    _device.Update(d);
                    _device.Save();

                    Damage damage = _damage.FindByDeviceId((int)d.Id);

                    damage.Isdeleted = 1;
                    _damage.Update(damage);
                    _damage.Save();
                }
            }


        }
    }
}