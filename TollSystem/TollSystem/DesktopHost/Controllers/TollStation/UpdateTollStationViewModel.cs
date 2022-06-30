using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TollSystem.Commands;

namespace TollSystem.DesktopHost.Controllers
{
    public class UpdateTollStationViewModel : BaseViewModel
    {
        public ICommand Update { get; set; }
        public ICommand Back { get; set; }

        public UpdateTollStationViewModel()
        {
            Update = new UpdateTollStationCommand();
            Back = new NavigateCommand(typeof(ShowTollStationViewModel));
        }
    }
}
