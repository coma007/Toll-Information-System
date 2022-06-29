using System;
using System.Windows.Input;
using TollSystem.DesktopHost.Controllers;

namespace TollSystem.Commands
{
    internal class FindTicketCommand : BaseCommand
    {

        private ReferentViewModel _referentViewModel;

        public FindTicketCommand(ReferentViewModel referentViewModel)
        {
            _referentViewModel = referentViewModel;
        }

        public override void Execute(object parameter)
        {
            _referentViewModel.IsPaymentEnabled = true;
        }
    }
}