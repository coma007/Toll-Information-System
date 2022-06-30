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
    public class CreateTollStationViewModel : BaseViewModel
    {
        private ObservableCollection<SectionListItem> _sections;
        public ObservableCollection<SectionListItem> Sections => _sections;


        public ICommand Create { get; set; }
        public ICommand Back { get; set; }

        public CreateTollStationViewModel()
        {
            Create = new CreateTollStationCommand();
            Back = new NavigateCommand(typeof(ShowTollStationViewModel));
        }


    }
}
