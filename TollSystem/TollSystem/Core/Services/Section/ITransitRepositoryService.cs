using System;
using System.Collections.Generic;
using System.Text;
using TollSystem.Infrastructure.Models;

namespace TollSystem.Core.Services
{
    public interface ITransitRepositoryService
    {
        public Transit FindByTicketId(int id);
        public Transit FindByTagId(int id);
        public List<Transit> FindByStationAndDate(int id, DateTime startDate, DateTime endDate);
    }
}
