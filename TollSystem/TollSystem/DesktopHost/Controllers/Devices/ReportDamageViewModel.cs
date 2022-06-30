using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Input;
using TollSystem.Commands;
using TollSystem.Core.Entities;
using TollSystem.Core.Services;
using TollSystem.Infrastructure.Models;

namespace TollSystem.DesktopHost.Controllers
{
    public class ReportDamageViewModel : BaseViewModel
    {
        private IDeviceRepositoryService _device = ServiceContainer.DeviceRepositoryService;
        public ICommand Back { get; set; }


        public List<string> Devices { get; set; }
        public string SelectedDevice { get; set; }

        private string _description;
        public string Description
        {
            get => _description;
            set
            {
                _description = value;
                OnPropertyChanged(Description);
            }
        }

        public List<Device> DeviceForBooth;

        public ICommand ReportDamage { get; set; }

        public ReportDamageViewModel()
        {
            Devices = new List<string>() { "SEMAPHORE", "RAMP", "PRINTER", "SCANNER FOR TAG", "SCANNER FOR LICENSE PLATES" };

            Back = new NavigateCommand(typeof(ReferentViewModel));
            ReportDamage = new ReportDamageCommand(this);
            DeviceForBooth = new List<Device>();

            GetDevices();
        }

        private void GetDevices()
        { 
            foreach (Device d in _device.FindByTollBooth(SystemCurrentData.CurrentStation.Id, (int)SystemCurrentData.CurrentTollBooth.OrdinalNumber))
            {
                DeviceForBooth.Add(d);
            }
        }
    }
}
