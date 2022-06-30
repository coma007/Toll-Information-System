using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TollSystem.Infrastructure.Models;

namespace TollSystem.Infrastructure.Repositories
{
    class TransitRepository : Repository<Transit>, ITransitRepository
    {
        public TransitRepository(ModelContext m) : base(m, m.Transit)
        { }

        public Transit FindByTicketId(int id)
        {
            List<Transit> transits = _table.Where(t => t.Ticketid == id).ToList();
            if (transits.Count > 0) return transits[0];
            return null;
        }

        public Transit FindByTagId(int id)
        {
            Transit transit = _table.Where(t => t.Tagid == id && t.Exitstationboothid == null).ToList()[0];
            return transit;
        }

        public List<Transit> FindByStationAndDate(int id, DateTime startDate, DateTime endDate)
        {
            List<Transit> transits = _table.Where(t => t.Exitstationid == id && startDate <= t.Exittime && t.Exittime <= endDate).ToList();
            return transits;
        }

    }
}
