﻿using System;
using System.Collections.Generic;
using System.Text;
using TollSystem.Core.Enumerations;

namespace TollSystem.Core.Entities
{
    class Tag
    {
        public int Id { get; set; }
        public VehicleCategory Category { get; set; }
        public int CurrentAmountRSD { get; set; }
        public string LicensePlate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public List<Transit> Transits { get; set; }

        public Tag()
        { }

        public Tag(int id, VehicleCategory category, int currentAmountRSD, string licensePlate,
                    DateTime expirationDate, List<Transit> transits)
        {
            Id = id;
            Category = category;
            CurrentAmountRSD = currentAmountRSD;
            LicensePlate = licensePlate;
            ExpirationDate = expirationDate;
            Transits = transits;
        }
    }
}
