using System;
using System.Collections.Generic;
using System.Text;
using TollSystem.Commands;
using TollSystem.DesktopHost;
using TollSystem.DesktopHost.Controllers;

namespace TollSystem.Commands
{
    public class LogoutCommand : BaseCommand
    {
        public override void Execute(object parameter)
        {
            NavigationStore.Instance().CurrentViewModel = new LoginViewModel();
        }
    }
}
