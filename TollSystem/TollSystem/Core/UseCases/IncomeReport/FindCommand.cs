using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using TollSystem.Core.Entities;
using TollSystem.DesktopHost.Controllers;

namespace TollSystem.Commands.IncomeReport
{
    public class FindCommand : BaseCommand
    {
        private IncomeAtAllStationsViewModel _model;
        private IIncomeReportService _reportService = ServiceContainer.IncomeReportService;

        public FindCommand(IncomeAtAllStationsViewModel model)
        {
            _model = model;
        }

        public override void Execute(object parameter)
        {
            try
            {

                CultureInfo provider = CultureInfo.InvariantCulture;

                Dictionary<TollStationEntity, List<double>> income
                    = _reportService.getIncomePerStation(
                        DateTime.ParseExact(_model.StartDateString, "dd.MM.yyyy.", provider),
                        DateTime.ParseExact(_model.EndDateString, "dd.MM.yyyy.", provider));

                _model.GetIncome(income);
            }
            catch (FormatException e)
            {
                MessageBox.Show("Datum nije u dobrom formatu", "GREŠKA", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    }
}