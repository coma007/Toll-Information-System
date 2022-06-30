using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TollSystem.Commands;

namespace TollSystem.DesktopHost.Controllers
{
    public class DamagesViewModel : BaseViewModel
    {
        public ICommand Back { get; set; }

        public DamagesViewModel()
        {
            Back = new NavigateCommand(typeof(StationMasterViewModel));
        }

    }
}
