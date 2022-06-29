using System;
using System.Collections.Generic;
using System.Text;
using TollSystem.Infrastructure.Models;

namespace TollSystem.Core.Services
{
    public interface ITollBoothRepositoryService
    {
        public List<Tollbooth> FindByStationId(int id);
        public Tollbooth FindByStationIdAndOrdinalNumber(int id, int ordinalNumber);
    }
}
