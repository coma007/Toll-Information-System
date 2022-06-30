using System;
using System.Collections.Generic;
using System.Text;

namespace TollSystem.Core.Entities
{
    public class PoliceReportEntity
    {
        public int Id { get; set; }
        public string LicensePlate { get; set; }
        public DateTime ReportDate { get; set; } 
        public double Speed { get; set; }

        public PoliceReportEntity()
        { }

        public PoliceReportEntity(int id, string licensePlate, DateTime reportDate, double speed)
        {
            Id = id;
            LicensePlate = licensePlate;
            ReportDate = reportDate;
            Speed = speed;
        }
    }
}
