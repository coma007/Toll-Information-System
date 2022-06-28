using System;
using System.Collections.Generic;
using System.Text;

namespace TollSystem.DesktopHost.Controllers
{
    public class MainViewModel : BaseViewModel
    {
        private NavigationStore navigation;

        public MainViewModel(NavigationStore navigation)
        {
            this.navigation = navigation;
        }
    }
}
