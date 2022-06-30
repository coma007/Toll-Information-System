using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using TollSystem.Commands;
using TollSystem.Core.UseCases;
using TollSystem.DesktopHost.ListItems;

namespace TollSystem.DesktopHost.Controllers
{
    public class IncomeAtStationViewModel : BaseViewModel
    {
        private string _startDateString;

        public string StartDateString
        {
            get => _startDateString;
            set
            {
                _startDateString = value;
                OnPropertyChanged(StartDateString);
            }
        }

        private string _endDateString;

        public string EndDateString
        {
            get => _endDateString;
            set
            {
                _endDateString = value;
                OnPropertyChanged(EndDateString);
            }
        }

        public ICommand Find { get; set; }
        public ICommand Back { get; set; }


        private ObservableCollection<IncomeListItem> _income;

        public ObservableCollection<IncomeListItem> Income
        {
            get => _income;
            set => _income = value;
        }

        public IncomeAtStationViewModel()
        {
            Income = new ObservableCollection<IncomeListItem>();
            Find = new ReportFindCommand(this);
            Back = new NavigateCommand(typeof(StationMasterViewModel));
        }
    }
}
