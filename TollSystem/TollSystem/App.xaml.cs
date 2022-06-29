using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
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
            //using (ModelContext m = new ModelContext())
            //{

                //Tollstation t = m.Tollstation.Where(a => a.Id == 1).ToList()[0];
                //Console.WriteLine(t);
                ////List<Tollbooth> tb = m.Tollbooth.Where(b => b.Station == t).ToList();
                ////List<Device> d = m.Device.Where(c => c.Tollbooth == tb[0]).ToList();
                ////m.Section.Add(new Section { Length = 100, Tollstation1 = t, Tollstation2 = t });
                //m.SaveChanges();
            //}


            base.OnStartup(e);
        }
    }
}
