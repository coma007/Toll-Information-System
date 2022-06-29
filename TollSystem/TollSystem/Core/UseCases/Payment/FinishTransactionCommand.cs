using System.Windows.Input;
using TollSystem.DesktopHost.Controllers;

namespace TollSystem.Commands
{
    public class FinishTransactionCommand : BaseCommand
    {
        private ReferentViewModel _referentViewModel;

        public FinishTransactionCommand(ReferentViewModel referentViewModel)
        {
            _referentViewModel = referentViewModel;
        }

        public override void Execute(object parameter)
        {

            _referentViewModel.IsRampEnabled = true;
            _referentViewModel.IsPaymentEnabled = false;
        }
    }
}