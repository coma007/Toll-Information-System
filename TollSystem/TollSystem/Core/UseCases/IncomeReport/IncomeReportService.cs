using System;
using System.Collections.Generic;
using TollSystem.Core.Entities;
using TollSystem.Core.Services;
using TollSystem.Infrastructure.Models;
using TollSystem.Infrastructure.Repositories;

namespace TollSystem.Commands.IncomeReport
{
    public class IncomeReportService : IIncomeReportService
    {
        // zameni repository sa servicima
        private IStationRepositoryService _stations;
        private ITransitRepository _transit;
        private ITransactionRepository _transactions;

        public IncomeReportService(IStationRepositoryService stations, ITransitRepository transit, ITransactionRepository transactions)
        {
            _stations = stations;
            _transit = transit;
            _transactions = transactions;
        }

        public Dictionary<TollStationEntity, List<double>> getIncomePerStation(DateTime startDate, DateTime endDate)
        {
            Dictionary<TollStationEntity, List<double>> income = new Dictionary<TollStationEntity, List<double>>();
            List<TollStationEntity> stations = new List<TollStationEntity>();
            //List<Tollstation> stations = _stations.findAll();

            foreach (TollStationEntity s in stations)
            {
                income.Add(s, getIncomeForStation(s.Id, startDate, endDate));
            }

            return income;
        }

        public List<double> getIncomeForStation(int stationId, DateTime startDate, DateTime endDate)
        {
            Tollstation station = _stations.FindById(stationId);
            List<double> income = new List<double>() {0, 0};
            List<Transit> transit = _transit.FindByStationAndDate((int)station.Id, startDate, endDate);

            foreach (Transit t in transit)
            {
                Transaction tr = _transactions.FindByTransitId((int)t.Id);

                if (tr.Currency.Equals("EUR"))
                {
                    income[1] += (double)tr.Price;
                }
                else
                {
                    income[0] += (double)tr.Price;
                }
            }

            return income;
        }
    }
}