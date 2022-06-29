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
    }
}