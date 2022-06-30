using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TollSystem.Commands;
using TollSystem.Core.Entities;

namespace TollSystem.DesktopHost.Controllers
{
    public class UpdateTollStationViewModel : BaseViewModel
    {
        public ICommand Update { get; set; }
        public ICommand Back { get; set; }

        private string _name;
        public string Name { get => _name; set { _name = value; } }

        private TollStationEntity _tollStation;
        public TollStationEntity TollStation { get => _tollStation; set { _tollStation = value; } }

        public UpdateTollStationViewModel(TollStationEntity tollStation)
        {
            TollStation = tollStation;
            Update = new UpdateTollStationCommand(this);
            Back = new NavigateCommand(typeof(ShowTollStationViewModel));
        }
    }
}
