using System.Windows.Input;
using TollSystem.Commands;
using TollSystem.Core.UseCases;
using TollSystem.DesktopHost.Controllers;

namespace TollSystem.DesktopHost.Controllers
{
    public class LoginViewModel : BaseViewModel
    {
        public ICommand LoginCommand { get; set; }

        private string _username;
        public string Username
        {
            get { return _username; }
            set { _username = value; OnPropertyChanged(nameof(Username)); }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set { _password = value; OnPropertyChanged(nameof(Password)); }
        }

        public LoginViewModel()
        {
            LoginCommand = new LoginCommand(this);
        }
    }
}