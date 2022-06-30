using System;
using System.Collections.Generic;
using System.Text;
using TollSystem.Commands.TollPayment;
using TollSystem.Core.Entities;
using TollSystem.Core.Enumerations;
using TollSystem.DesktopHost.Controllers;

namespace TollSystem.Commands
{
    public class LostTicketCommand : BaseCommand
    {
        private ReferentViewModel _referentViewModel;
        private IPhysicalPaymentService _paymentService = ServiceContainer.PhysicalPaymentService;

        public LostTicketCommand(ReferentViewModel referentViewModel)
        {
            _referentViewModel = referentViewModel;
        }

        public override void Execute(object parameter)
        {
            _referentViewModel.Exit = SystemCurrentData.CurrentStation;
            _referentViewModel.ExitString = _referentViewModel.Exit.Name;
            _referentViewModel.ExitTime = DateTime.Now.ToString();
            if (_referentViewModel.SelectedCurrency == Currency.RSD)
                _referentViewModel.Price = _paymentService.GetBiggestPrice(_referentViewModel.SelectedCategory);
            else _referentViewModel.Price = _paymentService.GetBiggestPrice(_referentViewModel.SelectedCategory, Currency.EUR);
            _referentViewModel.IsPaymentEnabled = true;
        }
    }
}
