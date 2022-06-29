using System;
using System.Windows.Input;
using TollSystem.Commands.TollPayment;
using TollSystem.Core.Entities;
using TollSystem.Core.Enumerations;
using TollSystem.DesktopHost.Controllers;

namespace TollSystem.Commands
{
    internal class FindTicketCommand : BaseCommand
    {

        private ReferentViewModel _referentViewModel;
        private PhysicalPaymentService _paymentService;

        public FindTicketCommand(ReferentViewModel referentViewModel)
        {
            _referentViewModel = referentViewModel;
        }

        public override void Execute(object parameter)
        {
            int id = Int32.Parse(_referentViewModel.TicketId);
            _referentViewModel.LicencePlate = _paymentService.FindLicensePlate(id);
            _referentViewModel.Entrance = _paymentService.FindEntranceStation(id);
            _referentViewModel.EntranceTime = _paymentService.FindEntranceTime(id).ToString();
            _referentViewModel.Exit = SystemCurrentData.CurrentStation;
            _referentViewModel.ExitTime = DateTime.Now.ToString();
            if (_referentViewModel.SelectedCurrency == Currency.RSD)
            _referentViewModel.Price = _paymentService.GetPrice(id, _referentViewModel.SelectedCategory);
            else _referentViewModel.Price = _paymentService.GetPrice(id, _referentViewModel.SelectedCategory, Currency.EUR);
            _referentViewModel.IsPaymentEnabled = true;
        }
    }
}