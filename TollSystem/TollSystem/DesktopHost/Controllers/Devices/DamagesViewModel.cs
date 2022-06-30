using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using TollSystem.Commands;
using TollSystem.Core.Entities;
using TollSystem.Core.Services;
using TollSystem.DesktopHost.ListItems;
using TollSystem.Infrastructure.Models;
using TollSystem.Infrastructure.Repositories;

namespace TollSystem.DesktopHost.Controllers
{
    public class DamagesViewModel : BaseViewModel
    {
        private IDeviceRepositoryService _device = ServiceContainer.DeviceRepositoryService;
        private ITollBoothRepositoryService _booths = ServiceContainer.TollBoothRepositoryService;
        private IDamageRepositoryService _damage = ServiceContainer.DamageRepositoryService;
        private IRepository<Scanner> _scanner = RepositoryContainer.ScannerRepository;


        private ObservableCollection<DamagedDeviceListItem> _devices;

        public ObservableCollection<DamagedDeviceListItem> Devices
        {
            get => _devices;
            set => _devices = value;
        }

        public ICommand Back { get; set; }

        public DamagesViewModel()
        {

            _devices = new ObservableCollection<DamagedDeviceListItem>();

            Back = new NavigateCommand(typeof(StationMasterViewModel));
            GetDevices();
        }

        private void GetDevices()
        {
            _devices.Clear();

            foreach (Tollbooth b in _booths.FindByStationId(SystemCurrentData.CurrentStation.Id))
            {

                foreach (Device d in _device.FindByTollBooth(SystemCurrentData.CurrentStation.Id, (int)b.Ordinalnumber))
                {
                    Damage damage = _damage.FindByDeviceId((int)d.Id);

                    if (damage is null || damage.Isdeleted == 1)
                    {
                        continue;
                    }

                    DeviceEntity device = null;
                    switch (d.Devicetype)
                    {
                        case "PRINTER":
                            device = new PrinterEntity(d);
                            break;
                        case "RAMP":
                            device = new RampEntity(d);
                            break;
                        case "SCANNER":
                            Scanner s = _scanner.GetById(d.Id);
                            device  = new ScannerEntity(s);
                            break;
                        case "SEMAPHORE":
                            device = new SemaphoreEntity(d);
                            break;
                        default:
                            break;
                    }



                    _devices.Add(new DamagedDeviceListItem((int)b.Ordinalnumber, device, damage.Description));
                }
            }
        }
    }
}
