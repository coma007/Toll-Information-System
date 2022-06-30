using System;
using System.Collections.Generic;
using TollSystem.Core.Entities;
using TollSystem.Infrastructure.Models;

namespace TollSystem.Commands.IncomeReport
{
    public interface IIncomeReportService
    {
        public Dictionary<TollStationEntity, List<double>> getIncomePerStation(DateTime startDate, DateTime endDate);

        public List<double> getIncomeForStation(int stationId, DateTime startDate, DateTime endDate);
    }
}