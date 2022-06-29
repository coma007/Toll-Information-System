using HealthInstitution.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using TollSystem.DesktopHost;
using TollSystem.DesktopHost.Controllers;

namespace TollSystem.Core.UseCases
{
    public class LoginCommand : BaseCommand
    {
        public override void Execute(object parameter)
        {
            NavigationStore.Instance().CurrentViewModel = new TollStationViewModel();
        }
    }
}
