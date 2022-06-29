using System;
using System.Collections.Generic;
using System.Text;
using TollSystem.Infrastructure.Models;

namespace TollSystem.Core.Entities
{
    public class TransitEntity
    {
        public int Id { get; set; }
        public DateTime EntranceTime { get; set; }
        public DateTime ExitTime { get; set; }
        public TollBoothEntity EntranceTollBooth { get; set; }
        public TollBoothEntity ExitTollBooth { get; set; }
        public TransactionEntity Transaction { get; set; }

        public TransitEntity()
        {

        }

        public TransitEntity(int id, DateTime entranceTime, DateTime exitTime,
                       TollBoothEntity entranceTollBooth, TollBoothEntity exitTollBooth,
                       TransactionEntity transaction)
        {
            Id = id;
            EntranceTime = entranceTime;
            ExitTime = exitTime;
            EntranceTollBooth = entranceTollBooth;
            ExitTollBooth = exitTollBooth;
            Transaction = transaction;
        }

        public TransitEntity(Transit transit)
        {
            Id = (int)transit.Id;
            EntranceTime = transit.Entrancetime;
            ExitTime = (DateTime)transit.Exittime;

        }
    }
}
