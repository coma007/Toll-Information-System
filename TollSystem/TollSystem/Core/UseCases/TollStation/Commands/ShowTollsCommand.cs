using System.Windows.Input;
using TollSystem.DesktopHost;
using TollSystem.DesktopHost.Controllers;

namespace TollSystem.Commands
{
    internal class ShowTollsCommand : BaseCommand
    {

        public override void Execute(object parameter)
        {
            NavigationStore.Instance().CurrentViewModel = new ShowTollStationViewModel();
        }
    }
}