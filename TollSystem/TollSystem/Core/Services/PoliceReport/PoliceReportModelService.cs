using System;
using System.Collections.Generic;
using System.Text;
using TollSystem.Core.Entities;
using TollSystem.Infrastructure.Models;

namespace TollSystem.Core.Services
{
    public class PoliceReportModelService : IPoliceReportModelService
    {
        public Policereport EntityToModel(PoliceReportEntity policeReport)
        {
            Policereport report = new Policereport();
            report.Id = policeReport.Id;
            report.Reportdate = policeReport.ReportDate;
            report.Licenseplate = policeReport.LicensePlate;
            report.Speed = (decimal)policeReport.Speed;

            return report;
        }
    }
}
