using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using TollSystem.Core.Entities;
using TollSystem.Core.Services;
using TollSystem.DesktopHost.Controllers;

namespace TollSystem.Commands
{
    class DeleteTollStationCommand : BaseCommand
    {
        private ShowTollStationViewModel _viewModel;

        public DeleteTollStationCommand(ShowTollStationViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            if (_viewModel.SelectedStation is null)
            {
                MessageBox.Show("Izaberite stanicu !");
                return;
            }
            TollStationEntity station = _viewModel.SelectedStation.Station;
            IDeleteTollStationService deleteStation = new DeleteTollStationService(ServiceContainer.TollStationRepositoryService, ServiceContainer.TollStationModelService);
            deleteStation.DeleteTollStation(station);
            _viewModel.GetAllStations();
        }
    }
}
