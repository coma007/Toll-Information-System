using System;
using System.Collections.Generic;
using System.Text;
using TollSystem.Core.Enumerations;

namespace TollSystem.Core.Entities
{
    class Ticket
    {
        public int Id { get; set; }
        public VehicleCategory Category { get; set; }
        public string LicensePlate { get; set; }

        public Ticket()
        { }

        public Ticket(int id, VehicleCategory category, string licensePlate)
        {
            Id = id;
            Category = category;
            LicensePlate = licensePlate;
        }
    }
}
