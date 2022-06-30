using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TollSystem.Commands;

namespace TollSystem.DesktopHost.Controllers
{
    public class IncomeAtStationViewModel : BaseViewModel
    {
        public ICommand Back { get; set; }

        public IncomeAtStationViewModel()
        {
            Back = new NavigateCommand(typeof(StationMasterViewModel));
        }
    }
}
