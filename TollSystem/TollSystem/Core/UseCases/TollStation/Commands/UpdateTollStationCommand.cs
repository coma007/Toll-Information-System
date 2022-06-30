using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using TollSystem.Core.Entities;
using TollSystem.Core.Services;
using TollSystem.DesktopHost;
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
            if (_viewModel.Name is null || _viewModel.Name.Trim().Equals(""))
            {
                MessageBox.Show("Potrebno je unijeti naziv stanice !");
                return;
            }
            IUpdateTollStationService service = new UpdateTollStationService(
                                                    ServiceContainer.TollStationRepositoryService,
                                                    ServiceContainer.TollStationModelService);
            _viewModel.TollStation.Name = _viewModel.Name;
            service.UpdateTollStation(_viewModel.TollStation);
            NavigationStore.Instance().CurrentViewModel = new ShowTollStationViewModel();
        }
    }
}
