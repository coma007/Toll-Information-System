using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TollSystem.Commands;

namespace TollSystem.DesktopHost.Controllers
{
    public class MainViewModel : BaseViewModel
    {
        private NavigationStore _navigationStore;
        public BaseViewModel CurrentViewModel => _navigationStore.CurrentViewModel;

        public ICommand Logout { get; set; }
        private string _logoutVisibility;
        public string LogoutVisibility { 
            get { return _logoutVisibility; }
            set { _logoutVisibility = value; OnPropertyChanged(nameof(LogoutVisibility)); }
        }

        public MainViewModel(NavigationStore navigation)
        {
            _navigationStore = navigation;
            LogoutVisibility = "Hidden";
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
            Logout = new LogoutCommand();
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
            LogoutVisibility = "Visible";
            if (_navigationStore.CurrentViewModel is LoginViewModel)
            {
                LogoutVisibility = "Hidden";
            }
        }
    }
}
