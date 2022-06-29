using System;
using System.Collections.Generic;
using System.Text;

namespace TollSystem.DesktopHost.Controllers
{
    public class ReferentViewModel : BaseViewModel
    {
        private string _ticketId;
        public string TicketId
        {
            get { return _ticketId; }
            set { _ticketId = value; OnPropertyChanged(nameof(TicketId)); }
        }
        private string _entrance;
        public string Entrance
        {
            get { return _entrance; }
            set { _entrance = value; OnPropertyChanged(nameof(Entrance)); }
        }
        private string _exit;
        public string Exit
        {
            get { return _exit; }
            set { _exit = value; OnPropertyChanged(nameof(Exit)); }
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




    }
}
