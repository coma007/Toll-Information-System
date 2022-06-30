using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using TollSystem.Commands;
using TollSystem.Core.Entities;
using TollSystem.Core.Services;
using TollSystem.DesktopHost.ListItems;
using TollSystem.Infrastructure.Models;

namespace TollSystem.DesktopHost.Controllers
{
    public class ShowTollStationViewModel : BaseViewModel
    {
        private ObservableCollection<TollStationListItem> _stations;
        public ObservableCollection<TollStationListItem> Stations => _stations;

        private TollStationListItem _selectedStation;

        public TollStationListItem SelectedStation
        {
            get { return _selectedStation; }
            set { _selectedStation = value; OnPropertyChanged(nameof(SelectedStation)); }
        }


        public ICommand Create { get; set; }
        public ICommand Update { get; set; }
        public ICommand Delete { get; set; }
        public ICommand Back { get; set; }

        public ShowTollStationViewModel()
        {
            Create = new NavigateCommand(typeof(CreateTollStationViewModel));

            Update = new ShowUpdateCommand(this);
            Delete = new DeleteTollStationCommand(this);
            Back = new NavigateCommand(typeof(AdminViewModel));

            GetAllStations();
        }

        public void GetAllStations()
        {
            ITollStationRepositoryService service = ServiceContainer.TollStationRepositoryService;
            ITollStationModelService modelService = ServiceContainer.TollStationModelService;
            ITollBoothRepositoryService boothService = ServiceContainer.TollBoothRepositoryService;
            IStaffModelService staffModel = ServiceContainer.StaffModelService;

            _stations = new ObservableCollection<TollStationListItem>();
            foreach (Tollstation station in service.GetAll())
            {
                TollStationEntity stationEntity = modelService.ModelToEntity(station);
                if (stationEntity == null) continue;
                TollStationListItem listItem = new TollStationListItem(stationEntity);
                _stations.Add(listItem);
            }
            OnPropertyChanged(nameof(Stations));
        }
    }
}
