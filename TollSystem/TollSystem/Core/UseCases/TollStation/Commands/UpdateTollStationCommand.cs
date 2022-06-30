using System;
using System.Collections.Generic;
using System.Text;
using TollSystem.Core.Entities;
using TollSystem.Core.Services;
using TollSystem.DesktopHost.Controllers;

namespace TollSystem.Commands
{
    class UpdateTollStationCommand : BaseCommand
    {
        private UpdateTollStationViewModel _viewModel;

        public UpdateTollStationCommand(UpdateTollStationViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            IUpdateTollStationService service = new UpdateTollStationService(
                                                    ServiceContainer.TollStationRepositoryService,
                                                    ServiceContainer.TollStationModelService);
            _viewModel.TollStation.Name = _viewModel.Name;
            service.UpdateTollStation(_viewModel.TollStation);
        }
    }
}
