using System;
using System.Windows;
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
        private IPhysicalPaymentService _paymentService = ServiceContainer.PhysicalPaymentService;

        public FindTicketCommand(ReferentViewModel referentViewModel)
        {
            _referentViewModel = referentViewModel;
        }

        public override void Execute(object parameter)
        {
            if (_referentViewModel.TicketId is null || _referentViewModel.TicketId.Trim().Equals(""))
            {
                MessageBox.Show("Upišite tiket !");
                return;
            }
            int id = 0;
            bool isNumeric = Int32.TryParse(_referentViewModel.TicketId, out id);
            if (isNumeric == false)
            {
                MessageBox.Show("Unesite tiket! ");
                return;
            }
            _referentViewModel.LicencePlate = _paymentService.FindLicensePlate(id);
            if (_referentViewModel.LicencePlate == null)
            {
                MessageBox.Show("Nepostojeći tiket!");
                return;
            }
            _referentViewModel.Entrance = _paymentService.FindEntranceStation(id);
            _referentViewModel.EntranceString = _referentViewModel.Entrance.Name;
            _referentViewModel.EntranceTime = _paymentService.FindEntranceTime(id).ToString();
            _referentViewModel.Exit = SystemCurrentData.CurrentStation;
            _referentViewModel.ExitString = _referentViewModel.Exit.Name;
            _referentViewModel.ExitTime = DateTime.Now.ToString();
            if (_referentViewModel.SelectedCurrency == Currency.RSD)
            _referentViewModel.Price = _paymentService.GetPrice(id, _referentViewModel.SelectedCategory);
            else _referentViewModel.Price = _paymentService.GetPrice(id, _referentViewModel.SelectedCategory, Currency.EUR);
            if (! _paymentService.CheckSpeed(id, _referentViewModel.LicencePlate))
            {
                MessageBox.Show("Poslata prijava policiji!");
            }
            _referentViewModel.IsPaymentEnabled = true;
        }
    }
}