using System;
using System.Collections.Generic;
using System.Text;
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
            TollStationEntity station = _viewModel.SelectedStation.Station;
            IDeleteTollStationService deleteStation = new DeleteTollStationService(ServiceContainer.TollStationRepositoryService, ServiceContainer.TollStationModelService);
            deleteStation.DeleteTollStation(station);
        }
    }
}
