using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using TollSystem.Infrastructure.Models;
using TollSystem.Infrastructure.Repositories;

namespace TollSystem
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            using (ModelContext m = new ModelContext())
            {

                //Tollstation t = m.Tollstation.Where(a => a.Id == 1).ToList()[0];
                //Console.WriteLine(t);
                //List<Tollbooth> tb = m.Tollbooth.Where(b => b.Station == t).ToList();
                //List<Device> d = m.Device.Where(c => c.Tollbooth == tb[0]).ToList();
                //m.Section.Add(new Section { Length = 100, Tollstation1 = t, Tollstation2 = t });
                //m.SaveChanges();
                TransitRepository r = new TransitRepository(m);
                DateTime dt1;
                DateTime.TryParseExact("2020-11-11 10:10:10", "yyyy-dd-MM hh:mm tt",
                                       CultureInfo.InvariantCulture,
                                       DateTimeStyles.None,
                                       out dt1);

                DateTime dt2;
                DateTime.TryParseExact("2022-11-11 10:10:10", "yyyy-dd-MM hh:mm tt",
                                       CultureInfo.InvariantCulture,
                                       DateTimeStyles.None,
                                       out dt2);
                r.FindByStationAndDate(1, dt1, dt2);
            }

            base.OnStartup(e);
        }
    }
}
