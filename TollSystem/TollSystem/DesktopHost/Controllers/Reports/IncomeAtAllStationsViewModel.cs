using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using TollSystem.Commands;
using TollSystem.Commands.IncomeReport;
using TollSystem.Core.Entities;
using TollSystem.DesktopHost.ListItems;

namespace TollSystem.DesktopHost.Controllers
{
    public class IncomeAtAllStationsViewModel : BaseViewModel
    {
        private string _startDateString;

        public string StartDateString
        {
            get => _startDateString;
            set
            {
                _startDateString = value;
                OnPropertyChanged(nameof(StartDateString));
            }
        }

        private string _endDateString;

        public string EndDateString
        {
            get => _endDateString;
            set
            {
                _endDateString = value;
                OnPropertyChanged(nameof(EndDateString));
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

        public IncomeAtAllStationsViewModel()
        {
            _income = new ObservableCollection<IncomeListItem>();
            Find = new FindCommand(this);
            Back = new NavigateCommand(typeof(ManagerViewModel));
        }

        public void GetIncome(Dictionary<TollStationEntity, List<double>> incomeData)
        {
            _income.Clear();

            foreach (TollStationEntity station in incomeData.Keys)
            {
                _income.Add(new IncomeListItem(station.Name, incomeData[station]));
            }
        }
    }
}