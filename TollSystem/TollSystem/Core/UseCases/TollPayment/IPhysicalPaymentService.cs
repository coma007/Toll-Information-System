using System;
using TollSystem.Core.Entities;
using TollSystem.Core.Enumerations;

namespace TollSystem.Commands.TollPayment
{
    public interface IPhysicalPaymentService
    {
        public TollStationEntity FindEntranceStation(int ticketId);

        public DateTime FindEntranceTime(int ticketId);

        public string FindLicensePlate(int ticketId);

        public bool CheckSpeed(int ticketId);

        public double GetPrice(int ticketId, VehicleCategory category, Currency c = Currency.RSD);

        public double GetChange(double price, double paid);

        public void Payment(int ticketId, VehicleCategory category, Currency c = Currency.RSD);
    }
}