using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using TollSystem.Commands;
using TollSystem.Core.Entities;
using TollSystem.Core.Services;
using TollSystem.DesktopHost.ListItems;
using TollSystem.Infrastructure.Models;

namespace TollSystem.DesktopHost.Controllers
{
    public class PricelistViewModel : BaseViewModel
    {

        private ObservableCollection<PriceListItem> _prices;

        public ObservableCollection<PriceListItem> Prices
        {
            get => _prices;
            set => _prices = value;
        }

        private IPriceRepositoryService _pricesRepository;

        private Pricelist _currentPricelist => ServiceContainer.PricelistRepositoryService.FindActive();

        public ICommand Back { get; set; }
        public PricelistViewModel()
        {
            _pricesRepository = ServiceContainer.PriceRepositoryService;
            _prices = new ObservableCollection<PriceListItem>();
            Back = new NavigateCommand(typeof(ManagerViewModel));

            FillPrices();
        }

        public void FillPrices()
        {
            foreach (Price p in _pricesRepository.FindByPricelistId((int)_currentPricelist.Id))
            {
                _prices.Add(new PriceListItem(ServiceContainer.PriceModelService.ModelToEntity(p)));
            }
        }
    }
}
