using System.Windows;
using System.Windows.Input;
using TollSystem.Commands;
using TollSystem.DesktopHost;
using TollSystem.DesktopHost.Controllers;

namespace TollSystem.Commands
{
    internal class ShowUpdateCommand : BaseCommand
    {
        private ShowTollStationViewModel _showTollStationViewModel;

        public ShowUpdateCommand(ShowTollStationViewModel showTollStationViewModel)
        {
            _showTollStationViewModel = showTollStationViewModel;
        }

        public override void Execute(object parameter)
        {
            if (_showTollStationViewModel.SelectedStation is null)
            {
                MessageBox.Show("Izaberite stanicu !");
                return;
            }
            NavigationStore.Instance().CurrentViewModel = new UpdateTollStationViewModel(_showTollStationViewModel.SelectedStation.Station);
        }
    }
}