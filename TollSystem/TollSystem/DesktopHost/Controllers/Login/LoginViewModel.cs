using System.Windows.Input;
using TollSystem.Core.UseCases;
using TollSystem.DesktopHost.Controllers;

namespace TollSystem.DesktopHost.Controllers
{
    public class LoginViewModel : BaseViewModel
    {
        public ICommand LoginCommand { get; set; }

        public LoginViewModel()
        {
            LoginCommand = new LoginCommand();
        }
    }
}