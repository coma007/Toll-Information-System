using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using TollSystem.Commands;
using TollSystem.Core.Entities;
using TollSystem.DesktopHost;
using TollSystem.DesktopHost.Controllers;
using TollSystem.Infrastructure.Models;

namespace TollSystem.Commands
{
    public class LoginCommand : BaseCommand
    {
        private LoginViewModel _model;

        public LoginCommand(LoginViewModel model)
        {
            _model = model;
        }

        public override void Execute(object parameter)
        {
            StaffEntity user = ServiceContainer.LoginService.Login(_model.Username, _model.Password);

            if (user is null)
            {
                Console.WriteLine("Nema korisnika");
            }
            else
            {
                SystemCurrentData.CurrentUser = user;
                if (user is ReferentEntity)
                {
                    SystemCurrentData.CurrentStation = ((ReferentEntity)user).TollStation;
                    Tollbooth t = RepositoryContainer.TollBoothRepository.FindByStationIdAndOrdinalNumber(SystemCurrentData.CurrentStation.Id, 1);
                    SystemCurrentData.CurrentTollBooth =
                        ServiceContainer.TollBoothModelService.ModelToEntity(t,
                            ServiceContainer.DeviceRepositoryService);
                    SystemCurrentData.CurrentTollBooth.TollStation = SystemCurrentData.CurrentStation;
                    NavigationStore.Instance().CurrentViewModel = new ReferentViewModel();
                } else if (user is StationMasterEntity)
                {
                    SystemCurrentData.CurrentStation = ((StationMasterEntity)user).TollStation;
                    NavigationStore.Instance().CurrentViewModel = new StationMasterViewModel();
                } else if (user is ManagerEntity)
                {
                    NavigationStore.Instance().CurrentViewModel = new ManagerViewModel();
                }
                else
                {
                    NavigationStore.Instance().CurrentViewModel = new AdminViewModel();
                }
            }
        }
    }
}
