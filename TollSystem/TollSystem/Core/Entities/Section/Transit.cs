using System;
using System.Collections.Generic;
using System.Text;

namespace TollSystem.Core.Entities
{
    class Transit
    {
        public int Id { get; set; }
        public DateTime EntranceTime { get; set; }
        public DateTime ExitTime { get; set; }
        public TollBooth EntranceTollBooth { get; set; }
        public TollBooth ExitTollBooth { get; set; }
        public Transaction Transaction { get; set; }

        public Transit()
        {

        }

        public Transit(int id, DateTime entranceTime, DateTime exitTime,
                       TollBooth entranceTollBooth, TollBooth exitTollBooth,
                       Transaction transaction)
        {
            Id = id;
            EntranceTime = entranceTime;
            ExitTime = exitTime;
            EntranceTollBooth = entranceTollBooth;
            ExitTollBooth = exitTollBooth;
            Transaction = transaction;
        }
    }
}
