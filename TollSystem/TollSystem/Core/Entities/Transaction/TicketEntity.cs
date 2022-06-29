using System;
using System.Collections.Generic;
using System.Text;
using TollSystem.Core.Enumerations;

namespace TollSystem.Core.Entities
{
    public class TicketEntity
    {
        public int Id { get; set; }
        public VehicleCategory Category { get; set; }
        public string LicensePlate { get; set; }
        public TransitEntity Transit { get; set; }

        public TicketEntity()
        { }

        public TicketEntity(int id, VehicleCategory category, string licensePlate, TransitEntity transit)
        {
            Id = id;
            Category = category;
            LicensePlate = licensePlate;
            Transit = transit;
        }
    }
}
