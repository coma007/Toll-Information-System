using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using TollSystem.Commands;
using TollSystem.Core.Entities;
using TollSystem.DesktopHost.ListItems;

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
            Update = new NavigateCommand(typeof(UpdateTollStationViewModel));
            Delete = new DeleteTollStationCommand();
            Back = new NavigateCommand(typeof(AdminViewModel));

            GetAllStations();
        }

        public void GetAllStations() { 
        
        }
    }
}
