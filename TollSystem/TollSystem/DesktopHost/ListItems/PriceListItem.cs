using TollSystem.Core.Entities;
using TollSystem.DesktopHost.Controllers;

namespace TollSystem.DesktopHost.ListItems
{
    public class PriceListItem : BaseViewModel
    {
        private PriceEntity _price;

        public string PriceFor
        {
            get
            {
                if (_price.Section is null)
                {
                    return "TAG";
                }
                else
                {
                    return _price.Section.EntranceTollStation.Name + "-" + _price.Section.ExitTollStation.Name;
                }
            }
        }

        public string Category => _price.Category.ToString();

        public double PriceRSD => _price.PriceRSD;
        public double PriceEUR => _price.PriceEUR;

        public PriceListItem(PriceEntity p)
        {
            _price = p;
        }
    }
}