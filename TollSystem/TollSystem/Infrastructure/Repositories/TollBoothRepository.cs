using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TollSystem.Infrastructure.Models;

namespace TollSystem.Infrastructure.Repositories
{
    public class TollBoothRepository : Repository<Tollbooth>, ITollBoothRepository
    {
        public TollBoothRepository(ModelContext context) : base(context, context.Tollbooth)
        {
        }

        public List<Tollbooth> FindByStationId(int id)
        {
            return _table.Where(t => t.Stationid == id).ToList();
        }

        public Tollbooth FindByStationIdAndOrdinalNumber(int id, int ordinalNumber)
        {
            return _table.Where(t => t.Stationid == id && t.Ordinalnumber == ordinalNumber).ToList()[0];
        }
    }
}