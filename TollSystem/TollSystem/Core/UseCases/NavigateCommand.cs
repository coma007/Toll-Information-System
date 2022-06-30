using System;
using System.Windows.Input;
using TollSystem.Commands;
using TollSystem.DesktopHost;
using TollSystem.DesktopHost.Controllers;

namespace TollSystem.Commands
{
    internal class NavigateCommand : BaseCommand
    {
        private Type _type;

        public NavigateCommand(Type type)
        {
            _type = type;
        }

        public override void Execute(object parameter)
        {
            NavigationStore.Instance().CurrentViewModel = (BaseViewModel)Activator.CreateInstance(_type);
        }
    }
}