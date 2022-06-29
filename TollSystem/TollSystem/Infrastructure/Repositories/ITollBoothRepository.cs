using System.Collections.Generic;
using System.Windows.Documents;
using TollSystem.Infrastructure.Models;

namespace TollSystem.Infrastructure.Repositories
{
    public interface ITollBoothRepository : IRepository<Tollbooth>
    {
        public List<Tollbooth> FindByStationId(int id);
    }
}