using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows;
using TollSystem.Commands;
using TollSystem.Commands.IncomeReport;
using TollSystem.Core.Entities;
using TollSystem.DesktopHost.Controllers;
using TollSystem.DesktopHost.ListItems;

namespace TollSystem.Core.UseCases
{
    public class ReportFindCommand : BaseCommand
    {
        private IncomeAtStationViewModel _model;
        private IIncomeReportService _reportService = ServiceContainer.IncomeReportService;

        public ReportFindCommand(IncomeAtStationViewModel model) 
        {
            _model = model;
        }

        public override void Execute(object parameter)
        {
            try
            {
                CultureInfo provider = CultureInfo.InvariantCulture;

               List<double> income
                    = _reportService.getIncomeForStation(SystemCurrentData.CurrentStation.Id,
                        DateTime.ParseExact(_model.StartDateString, "dd.MM.yyyy.", provider),
                        DateTime.ParseExact(_model.EndDateString, "dd.MM.yyyy.", provider));

                IncomeListItem listItem = new IncomeListItem(SystemCurrentData.CurrentStation.Name, income);
                _model.Income.Add(listItem);
            }
            catch (FormatException e)
            {
                MessageBox.Show("Datum nije u dobrom formatu", "GREŠKA", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (ArgumentNullException e)
            {
                MessageBox.Show("Unesite datum", "GREŠKA", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
