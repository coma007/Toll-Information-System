using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TollSystem.Commands;

namespace TollSystem.DesktopHost.Controllers
{
    public class StationMasterViewModel : BaseViewModel
    {
        public ICommand Reports { get; set; }
        public ICommand Station { get; set; }

        public StationMasterViewModel()
        {
            Reports = new NavigateCommand(typeof(IncomeAtStationViewModel));
            Station = new NavigateCommand(typeof(DamagesViewModel));
        }
    }
}
