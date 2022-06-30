using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TollSystem.Commands;

namespace TollSystem.DesktopHost.Controllers
{
    public class ManagerViewModel : BaseViewModel
    {
        public ICommand Pricelist { get; set; }

        public ManagerViewModel()
        {
            Pricelist = new NavigateCommand(typeof(PricelistViewModel));
        }
    }
}
