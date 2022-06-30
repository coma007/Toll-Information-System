using TollSystem.Core.Entities;
using TollSystem.DesktopHost.Controllers;

namespace TollSystem.DesktopHost.ListItems
{
    class SectionListItem : BaseViewModel
    {
        TollStationEntity _station;
        public TollStationEntity Station => _station;
        private double _length;
        public double Length
        {
            get { return _length; }
            set { _length = value; }
        }
        private double _priceRSD;
        public double PriceRSD
        {
            get { return _priceRSD; }
            set { _priceRSD = value; }
        }
        private double _priceEUR;
        public double PriceEUR
        {
            get { return _priceEUR; }
            set { _priceEUR = value; }
        }
        public SectionListItem(TollStationEntity station)
        {
            _station = station;
        }
    }
}
