using System;
using System.Collections.Generic;
using System.Text;
using TollSystem.Commands;
using TollSystem.Commands.TollStationCreation;
using TollSystem.Core.Entities;
using TollSystem.DesktopHost.Controllers;
using TollSystem.DesktopHost.ListItems;

namespace TollSystem.Commands
{
    public class CreateTollStationCommand : BaseCommand
    {
        private CreateTollStationViewModel _model;
        private ITollStationCreationService _creator => ServiceContainer.TollStationCreationService;

        public CreateTollStationCommand(CreateTollStationViewModel model)
        {
            _model = model;
        }
        public override void Execute(object parameter)
        {
            Dictionary<int, List<double>> sections = new Dictionary<int, List<double>>();
            foreach (SectionListItem s in _model.Sections)
            {
                sections.Add(s.Station.Id, new List<double>() { s.Length, s.PriceRSD, s.PriceEUR });
            }
            _creator.CreateStation(_model.Name, _model.BoothsNumber, sections);
        }
    }
}
