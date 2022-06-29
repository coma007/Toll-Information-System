using System.Windows.Input;
using TollSystem.Commands.TollPayment;
using TollSystem.DesktopHost.Controllers;

namespace TollSystem.Commands
{
    public class FinishTransactionCommand : BaseCommand
    {
        private ReferentViewModel _referentViewModel;
        private PhysicalPaymentService _paymentService;

        public FinishTransactionCommand(ReferentViewModel referentViewModel)
        {
            _referentViewModel = referentViewModel;
        }

        public override void Execute(object parameter)
        {
            double price = _referentViewModel.Price;
            double paid = _referentViewModel.Paid;
            _referentViewModel.Change = _paymentService.GetChange(price, paid);
            _referentViewModel.IsRampEnabled = true;
            _referentViewModel.IsPaymentEnabled = false;
        }
    }
}