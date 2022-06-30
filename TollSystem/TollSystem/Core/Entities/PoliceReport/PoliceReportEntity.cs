using System;
using System.Collections.Generic;
using System.Text;

namespace TollSystem.Core.Entities
{
    public class PoliceReportEntity
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string LicensePlate { get; set; }
        public double Speed { get; set; }

        public PoliceReportEntity()
        {

        }

        public PoliceReportEntity(int id, DateTime date, string licensePlate, double spped)
        {
            Id = id;
            Date = date;
            LicensePlate = licensePlate;
            Speed = Speed;
        }
    }
}
