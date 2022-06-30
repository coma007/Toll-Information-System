using System;
using System.Collections.Generic;
using System.Text;
using TollSystem.Core.Enumerations;
using TollSystem.Infrastructure.Models;

namespace TollSystem.Core.Entities
{
    public class TagEntity
    {
        public int Id { get; set; }
        public VehicleCategory Category { get; set; }
        public int CurrentAmountRSD { get; set; }
        public string LicensePlate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public List<TransitEntity> Transits { get; set; }

        public TagEntity()
        { }

        public TagEntity(int id, VehicleCategory category, int currentAmountRSD, string licensePlate,
                    DateTime expirationDate, List<TransitEntity> transits)
        {
            Id = id;
            Category = category;
            CurrentAmountRSD = currentAmountRSD;
            LicensePlate = licensePlate;
            ExpirationDate = expirationDate;
            Transits = transits;
        }

        public TagEntity(Tag tag)
        {
            Id = (int)tag.Id;
            Category = (VehicleCategory)Enum.Parse(typeof(VehicleCategory), tag.Category, true);
            CurrentAmountRSD = (int)tag.Currentbalance;
            LicensePlate = tag.Licenseplate;
            ExpirationDate = (DateTime)tag.Expirationdate;
            Transits = null;
        }
    }
}
