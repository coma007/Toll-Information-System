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
    public class CreateTollStationViewModel : BaseViewModel
    {
        private ObservableCollection<SectionListItem> _sections;
        public ObservableCollection<SectionListItem> Sections => _sections;

        public ICommand Create { get; set; }
        public ICommand Back { get; set; }

        private string _name;
        public string Name { get => _name; set { _name = value; } }

        private int _boothsNumber;
        public int BoothsNumber { get => _boothsNumber; set { _boothsNumber = value; } }

        public CreateTollStationViewModel()
        {
            Create = new CreateTollStationCommand();
            Back = new NavigateCommand(typeof(ShowTollStationViewModel));

            GetSections();
        }

        public void GetSections()
        {
            ITollStationRepositoryService service = ServiceContainer.TollStationRepositoryService;
            ITollStationModelService modelService = ServiceContainer.TollStationModelService;;

            _sections = new ObservableCollection<SectionListItem>();
            foreach (Tollstation station in service.GetAll())
            {
                TollStationEntity stationEntity = modelService.ModelToEntity(station);
                if (stationEntity == null) continue;
                SectionListItem listItem = new SectionListItem(stationEntity);

                _sections.Add(listItem);
            }
            OnPropertyChanged(nameof(Sections));
        }


    }
}
