using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using TollSystem.Core.Entities;
using TollSystem.DesktopHost;
using TollSystem.DesktopHost.Controllers;
using TollSystem.Infrastructure.Models;
using TollSystem.Infrastructure.Repositories;

namespace TollSystem
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private NavigationStore _navigation;

        public App() {
            _navigation = NavigationStore.Instance();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            _navigation.CurrentViewModel = new LoginViewModel();
            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigation)
            };
            MainWindow.Show();
            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            RepositoryContainer.Context.Dispose();
            base.OnExit(e);
        }
    }
}
