using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TollSystem.Commands;

namespace TollSystem.DesktopHost.Controllers
{
    public class ReportDamageViewModel : BaseViewModel
    {
        public ICommand Back { get; set; }

        public ReportDamageViewModel()
        {
            Back = new NavigateCommand(typeof(ReferentViewModel));
        }
    }
}
