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
        private ITollStationRepositoryService _stations;
        private ITollStationModelService _stationModelService;
        private ITransitRepositoryService _transit;
        private ITransactionRepositoryService _transactions;

        public IncomeReportService(ITollStationRepositoryService stations, ITransitRepositoryService transit, ITransactionRepositoryService transactions, ITollStationModelService stationModelService)
        {
            _stations = stations;
            _transit = transit;
            _transactions = transactions;
            _stationModelService = stationModelService;
        }

        public Dictionary<TollStationEntity, List<double>> getIncomePerStation(DateTime startDate, DateTime endDate)
        {
            Dictionary<TollStationEntity, List<double>> income = new Dictionary<TollStationEntity, List<double>>();
            
            List<Tollstation> stationModels = _stations.FindAll();

            foreach (Tollstation s in stationModels)
            {
                income.Add(_stationModelService.ModelToEntity(s), getIncomeForStation((int)s.Id, startDate, endDate));
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