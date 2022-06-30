using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TollSystem.Commands;

namespace TollSystem.DesktopHost.Controllers
{
    public class AdminViewModel : BaseViewModel
    {

        public ICommand Tolls { get; set; }

        public AdminViewModel()
        {
            Tolls = new NavigateCommand(typeof(ShowTollStationViewModel));
        }
    }
}
