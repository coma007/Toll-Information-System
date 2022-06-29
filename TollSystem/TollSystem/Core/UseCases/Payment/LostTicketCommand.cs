using System;
using System.Collections.Generic;
using System.Text;
using TollSystem.DesktopHost.Controllers;

namespace TollSystem.Commands
{
    public class LostTicketCommand : BaseCommand
    {
        private ReferentViewModel _referentViewModel;

        public LostTicketCommand(ReferentViewModel referentViewModel)
        {
            _referentViewModel = referentViewModel;
        }

        public override void Execute(object parameter)
        {
        }
    }
}
