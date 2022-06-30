using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using TollSystem.Core.Entities;
using TollSystem.Core.Enumerations;
using TollSystem.Core.Services;
using TollSystem.Infrastructure.Models;
using TollSystem.Infrastructure.Repositories;

namespace TollSystem.Commands.TollPayment
{
    public class PhysicalPaymentService : IPhysicalPaymentService
    {
        private ITransitRepository _transit;
        private ITollStationRepositoryService _stations;
        private IRepository<Ticket> _tickets;
        private Repository<Section> _sections;
        private IPricelistRepository _pricelist;
        private IPriceRepository _prices;
        private IRepository<Transaction> _transactions;

        public PhysicalPaymentService(ITransitRepository transit, ITollStationRepositoryService stations, IRepository<Ticket> tickets, Repository<Section> sections, IPricelistRepository pricelist, IPriceRepository prices, IRepository<Transaction> transactions)
        {
            _transit = transit;
            _stations = stations;
            _tickets = tickets;
            _sections = sections;
            _pricelist = pricelist;
            _prices = prices;
            _transactions = transactions;
        }

        public TollStationEntity FindEntranceStation(int ticketId)
        {
            Transit t = _transit.FindByTicketId(ticketId);
            Tollstation s = _stations.FindById((int)t.Entrancestationid);

            return new TollStationEntity((int)s.Id, s.Name);
        }

        public DateTime FindEntranceTime(int ticketId)
        {
            Transit t = _transit.FindByTicketId(ticketId);

            return t.Entrancetime;
        }

        public string FindLicensePlate(int ticketId)
        {
            Ticket t = _tickets.GetById((decimal)ticketId);

            return t.Licenseplate;
        }

        public bool CheckSpeed(int ticketId, string licensePlate)
        {
            Transit t = _transit.FindByTicketId(ticketId);
            Section s = _sections.Table.Where(sec =>
                (sec.Tollstation1id == t.Entrancestationid && sec.Tollstation2id == SystemCurrentData.CurrentStation.Id) || (sec.Tollstation2id == t.Entrancestationid && sec.Tollstation1id == SystemCurrentData.CurrentStation.Id)).ToList()[0];
            double length = (double)s.Length;
            double time = DateTime.Now.Subtract(t.Entrancetime).TotalHours;

            if ((length / time) > 130)
            {
                Policereport report = new Policereport();
                report.Licenseplate = licensePlate;
                report.Reportdate = DateTime.Now;
                report.Speed = Decimal.Round((decimal)(length / time), 1);
                return false;
            }
            return true;
        }

        public double GetPrice(int ticketId, VehicleCategory category, Currency c = Currency.RSD)
        {
            Transit t = _transit.FindByTicketId(ticketId);
            Section s = _sections.Table.Where(sec =>
                (sec.Tollstation1id == t.Entrancestationid && sec.Tollstation2id == SystemCurrentData.CurrentStation.Id) || (sec.Tollstation2id == t.Entrancestationid && sec.Tollstation1id == SystemCurrentData.CurrentStation.Id)).ToList()[0];

            Pricelist pricelist = _pricelist.FindActive();
            List<Price> price = _prices.FindByPricelistAndSectionId((int)pricelist.Id, (int)s.Id);

            foreach (Price p in price)
            {
                if (p.Category.ToLower().Equals(category.ToString().ToLower()))
                {
                    if (c == Currency.RSD)
                    {
                        return (double)p.Pricersd;
                    }
                    else
                    {
                        return (double)p.Priceeur;
                    }
                }
            }

            return 0.0;
        }

        public double GetChange(double price, double paid)
        {
            return paid - price;
        }

        public void Payment(int ticketId, VehicleCategory category, Currency c = Currency.RSD)
        {
            Transit t = _transit.FindByTicketId(ticketId);
            Section s = _sections.Table.Where(sec =>
                (sec.Tollstation1id == t.Entrancestationid && sec.Tollstation2id == SystemCurrentData.CurrentStation.Id) || (sec.Tollstation2id == t.Entrancestationid && sec.Tollstation1id == SystemCurrentData.CurrentStation.Id)).ToList()[0];

            Pricelist p = _pricelist.FindActive();
            double price = GetPrice(ticketId, category);

            _transactions.Add(new Transaction()
            {
                Currency = c.ToString(),
                Price = (decimal)price,
                Transitid = t.Id
            });
            _transactions.Save();

            t.Exitstationid = SystemCurrentData.CurrentStation.Id;
            t.Exitstationboothid = SystemCurrentData.CurrentTollBooth.OrdinalNumber;
            t.Exittime = DateTime.Now;
            _transit.Update(t);
            _transit.Save();

        }

        public double GetBiggestPrice(VehicleCategory category, Currency c = Currency.RSD)
        {
            Pricelist pricelist = _pricelist.FindActive();
            Price price = _prices.FindBiggestPrice((int)pricelist.Id, category);
            if (c == Currency.RSD) return (double)price.Pricersd;
            else return (double)price.Priceeur;

        }
    }
}