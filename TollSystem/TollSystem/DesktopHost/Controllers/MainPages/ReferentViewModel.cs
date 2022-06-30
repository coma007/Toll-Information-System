using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using TollSystem.Commands;
using TollSystem.Commands.TollPayment;
using TollSystem.Core.Entities;
using TollSystem.Core.Enumerations;

namespace TollSystem.DesktopHost.Controllers
{
    public class ReferentViewModel : BaseViewModel
    {
        private IPhysicalPaymentService _paymentService = ServiceContainer.PhysicalPaymentService;
        private string _ticketId;
        public string TicketId
        {
            get { return _ticketId; }
            set { _ticketId = value; OnPropertyChanged(nameof(TicketId)); }
        }
        private TollStationEntity _entrance;
        public TollStationEntity Entrance
        {
            get { return _entrance; }
            set { _entrance = value; OnPropertyChanged(nameof(Entrance)); }
        }
        private string _entranceString;
        public string EntranceString
        {
            get { return _entranceString; }
            set { _entranceString = value; OnPropertyChanged(nameof(EntranceString)); }
        }
        private TollStationEntity _exit;
        public TollStationEntity Exit
        {
            get { return _exit; }
            set { _exit = value; OnPropertyChanged(nameof(Exit)); }
        }

        private String _exitString;
        public String ExitString
        {
            get { return _exitString; }
            set { _exitString = value; OnPropertyChanged(nameof(ExitString)); }
        }
        private string _entranceTime;
        public string EntranceTime
        {
            get { return _entranceTime; }
            set { _entranceTime = value; OnPropertyChanged(nameof(EntranceTime)); }
        }

        private string _exitTime;
        public string ExitTime
        {
            get { return _exitTime; }
            set { _exitTime = value; OnPropertyChanged(nameof(ExitTime)); }
        }

        private string _licencePlate;
        public string LicencePlate
        {
            get { return _licencePlate; }
            set { _licencePlate = value; OnPropertyChanged(nameof(LicencePlate)); }
        }

        private ObservableCollection<VehicleCategory> _categories;
        public ObservableCollection<VehicleCategory> Categories => _categories;

        private VehicleCategory _selectedCategory;

        public VehicleCategory SelectedCategory
        {
            get { return _selectedCategory; }
            set 
            {
                _selectedCategory = value; 
                OnPropertyChanged(nameof(SelectedCategory));
                if (TicketId != null)
                    Price = _paymentService.GetPrice(Int32.Parse(TicketId), SelectedCategory, SelectedCurrency);
                else Price = _paymentService.GetBiggestPrice(SelectedCategory, SelectedCurrency);
            }
        }

        private ObservableCollection<Currency> _currencies;
        public ObservableCollection<Currency> Currencies => _currencies;

        private Currency _selectedCurrency;

        public Currency SelectedCurrency
        {
            get { return _selectedCurrency; }
            set 
            { 
                _selectedCurrency = value; 
                OnPropertyChanged(nameof(SelectedCurrency));
                if (TicketId != null)
                    Price = _paymentService.GetPrice(Int32.Parse(TicketId), SelectedCategory, SelectedCurrency);
                else Price = _paymentService.GetBiggestPrice(SelectedCategory, SelectedCurrency);
            }
        }

        private double _price;

        public double Price
        {
            get { return _price; }
            set { _price = value; OnPropertyChanged(nameof(Price)); }
        }
        private double _paid;

        public double Paid
        {
            get { return _paid; }
            set 
            { 
                _paid = value;
                OnPropertyChanged(nameof(Paid));
                OnPropertyChanged(nameof(IsPaymentEnabled));
            }
        }
        private double _change;

        public double Change
        {
            get { return _change; }
            set { _change = value; OnPropertyChanged(nameof(Change)); }
        }


        private int _rampPosition;
        public int RampPosition
        {
            get { return _rampPosition; }
            set { _rampPosition = value; OnPropertyChanged(nameof(RampPosition)); }
        }
        private string _semaphoreState;
        public string SemaphoreState
        {
            get { return _semaphoreState; }
            set { _semaphoreState = value; OnPropertyChanged(nameof(SemaphoreState)); }
        }


        public ICommand FindTicket { get; set; }
        public ICommand LostTicket { get; set; }
        public ICommand FinishTransaction { get; set; }
        public ICommand RaiseRamp { get; set; }
        public ICommand ReportDamage { get; set; }

        private bool _isRampEnabled;

        public bool IsRampEnabled
        {
            set { _isRampEnabled = value; OnPropertyChanged(nameof(IsRampEnabled)); }
            get { return _isRampEnabled; }
        }
        private bool _isPayementEnabled;
        public bool IsPaymentEnabled
        {
            set { _isPayementEnabled = value; OnPropertyChanged(nameof(IsPaymentEnabled)); }
            get { return _isPayementEnabled && _paid > _price; }
        }



        public ReferentViewModel()
        {
            RampPosition = 20;
            SemaphoreState = "Red";
            
            FindTicket = new FindTicketCommand(this);
            LostTicket = new LostTicketCommand(this);
            FinishTransaction = new FinishTransactionCommand(this);
            RaiseRamp = new RaiseRampCommand(this);
            ReportDamage = new RepordDamageCommand();

            FillCategoryList();
            FillCurrencyList();
        }

        private void FillCategoryList()
        {
            _categories = new ObservableCollection<VehicleCategory>();
            foreach (VehicleCategory category in Enum.GetValues(typeof(VehicleCategory)))
            {
                _categories.Add(category);
            }
            SelectedCategory = _categories[0];
            OnPropertyChanged(nameof(Categories));
        }

        private void FillCurrencyList()
        {
            _currencies = new ObservableCollection<Currency>();
            foreach (Currency currency in Enum.GetValues(typeof(Currency)))
            {
                _currencies.Add(currency);
            }
            SelectedCurrency = _currencies[0];
            OnPropertyChanged(nameof(Categories));
        }

        public void ResetForm()
        {
            TicketId = null;
            SelectedCategory = _categories[0];
            LicencePlate = null;
            Entrance = null;
            EntranceString = "";
            Exit = null;
            ExitString = "";
            EntranceTime = null;
            ExitTime = null;
            SelectedCurrency = _currencies[0];
            Price = 0;
            Paid = 0;
            Change = 0;
        }
    }
}
