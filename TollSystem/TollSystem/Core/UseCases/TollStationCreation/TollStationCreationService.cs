using System.Collections.Generic;
using System.Linq;
using TollSystem.Infrastructure.Models;
using TollSystem.Infrastructure.Repositories;

namespace TollSystem.Commands.TollStationCreation
{
    public class TollStationCreationService : ITollStationCreationService
    {
        private Repository<Tollstation> _stations;
        private IRepository<Tollbooth> _booths;
        private IRepository<Device> _devices;
        private Repository<Section> _sections;
        private IPricelistRepository _pricelist;
        private IPriceRepository _prices;

        public TollStationCreationService(Repository<Tollstation> stations, IRepository<Tollbooth> booths, IRepository<Device> devices, Repository<Section> sections, IPricelistRepository pricelist, IPriceRepository prices)
        {
            _stations = stations;
            _booths = booths;
            _devices = devices;
            _sections = sections;
            _pricelist = pricelist;
            _prices = prices;
        }

        // prva vrednost duzina, druga cena u dinarima, treca cena u eurima
        public bool CreateStation(string name, int numberOfBooths, Dictionary<int, List<double>> sections)
        {

            Tollstation t = new Tollstation();
            t.Name = name;
            _stations.Add(t);
            _stations.Save();
            t = _stations.Table.Where(st => st.Name == name).ToList()[0];

            createTollBooths((int)t.Id, numberOfBooths);

            foreach (int stationId in sections.Keys)
            {
                _sections.Add(new Section()
                {
                    Length = (decimal)sections[stationId][0],
                    Tollstation1id = t.Id,
                    Tollstation2id = stationId
                });

                _sections.Save();

                Section s = _sections.Table.Where(st => st.Tollstation1id == t.Id && st.Tollstation2id == stationId)
                    .ToList()[0];

                Pricelist p = _pricelist.FindActive();

                _prices.Add(new Price()
                {
                    Pricelistid = p.Id,
                    Pricersd = (decimal)sections[stationId][1],
                    Priceeur = (decimal)sections[stationId][2],
                    Sectionid = s.Id
                });
                _prices.Save();
            }

            return true;
        }

        private void createTollBooths(int stationId, int numberOfBooths)
        {
            for (int i = 0; i < numberOfBooths; i++)
            {
                Tollbooth t = new Tollbooth();
                t.Stationid = stationId;
                t.Ordinalnumber = i + 1;
                _booths.Add(t);

                _booths.Save();

                createDevices(t.Stationid, t.Ordinalnumber);
            }
        }

        private void createDevices(decimal stationid, decimal ordinalnumber)
        {
            _devices.Add(new Device()
            {
                Stationid = stationid,
                Tollboothnumber = ordinalnumber,
                Devicetype = ""
            });
            //napravi sve uredjaje

            _devices.Save();
        }
    }
}