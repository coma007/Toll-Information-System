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
            _navigation.CurrentViewModel = new IncomeAtStationViewModel();
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

            //ServiceContainer.TollStationCreationService.CreateStation("Ime", 5, new Dictionary<int, List<double>>()
            //{
            //    { 1, new List<double>() { 100, 100, 5.00 } },
            //    { 2, new List<double>() { 100, 100, 5.00 } },
            //    { 3, new List<double>() { 100, 100, 5.00 } },
            //    { 4, new List<double>() { 100, 100, 5.00 } },
            //    { 5, new List<double>() { 100, 100, 5.00 } },
            //    { 6, new List<double>() { 100, 100, 5.00 } },
            //    { 7, new List<double>() { 100, 100, 5.00 } },
            //    { 8, new List<double>() { 100, 100, 5.00 } }
            //});
            base.OnStartup(e);
        }
    }
}
