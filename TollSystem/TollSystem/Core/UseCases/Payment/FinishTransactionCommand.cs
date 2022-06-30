using System;
using System.Windows.Input;
using TollSystem.Commands.TollPayment;
using TollSystem.Core.Entities;
using TollSystem.Core.Enumerations;
using TollSystem.DesktopHost.Controllers;

namespace TollSystem.Commands
{
    public class FinishTransactionCommand : BaseCommand
    {
        private ReferentViewModel _referentViewModel;
        private IPhysicalPaymentService _paymentService = ServiceContainer.PhysicalPaymentService;

        public FinishTransactionCommand(ReferentViewModel referentViewModel)
        {
            _referentViewModel = referentViewModel;
        }

        public override void Execute(object parameter)
        {
            double price = _referentViewModel.Price;
            double paid = _referentViewModel.Paid;
            _referentViewModel.Change = _paymentService.GetChange(price, paid);
            if (_referentViewModel.TicketId != null)
            {
                int id = Int32.Parse(_referentViewModel.TicketId);
                VehicleCategory category = _referentViewModel.SelectedCategory;
                Currency currency = _referentViewModel.SelectedCurrency;
                _paymentService.Payment(id, category, currency);
            }
            _referentViewModel.IsRampEnabled = true;
            _referentViewModel.IsPaymentEnabled = false;
        }
    }
}