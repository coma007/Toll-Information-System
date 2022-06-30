using System;
using System.Collections.Generic;
using System.Text;

namespace TollSystem.Core.Entities
{
    public class PoliceReportEntity
    {
        public int Id { get; set; }
        public DateTime ReportDate { get; set; }
        public string LicensePlate { get; set; }
        public double Speed { get; set; }

        public PoliceReportEntity()
        {

        }

        public PoliceReportEntity(int id, DateTime date, string licensePlate, double spped)
        {
            Id = id;
            ReportDate = date;
            LicensePlate = licensePlate;
            Speed = Speed;
        }
    }
}
