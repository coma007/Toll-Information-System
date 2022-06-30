using System;
using System.Collections.Generic;
using System.Text;
using TollSystem.Core.Entities;
using TollSystem.Core.Services;
using TollSystem.DesktopHost.Controllers;
using TollSystem.Infrastructure.Models;
using TollSystem.Infrastructure.Repositories;

namespace TollSystem.Commands
{
    public class ReportDamageCommand : BaseCommand
    {
        private ReportDamageViewModel _model;
        private IRepository<Scanner> _scanner = RepositoryContainer.ScannerRepository;
        private IDeviceRepositoryService _device = ServiceContainer.DeviceRepositoryService;
        private IDamageRepositoryService _damage = ServiceContainer.DamageRepositoryService;

        public ReportDamageCommand(ReportDamageViewModel model)
        {
            _model = model;
        }

        public override void Execute(object parameter)
        {
            string type = null;
            string scannerType = null;
            switch (_model.SelectedDevice)
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

            foreach (Device d in _model.DeviceForBooth)
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

                    d.Isdamaged = 1;
                    _device.Update(d);
                    _device.Save();

                    _damage.Add(new Damage()
                    {
                        Deviceid = d.Id,
                        Description = _model.Description
                    });
                    _damage.Save();
                }
            }

        }
    }
}
