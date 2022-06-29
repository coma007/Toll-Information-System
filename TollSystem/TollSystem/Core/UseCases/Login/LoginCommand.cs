using TollSystem.DesktopHost;
using TollSystem.DesktopHost.Controllers;

namespace TollSystem.Commands
{
    public class LoginCommand : BaseCommand
    {
        public override void Execute(object parameter)
        {
            NavigationStore.Instance().CurrentViewModel = new TollStationViewModel();
        }
    }
}
