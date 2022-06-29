using System.Collections.Generic;
using System.Windows.Documents;
using TollSystem.Infrastructure.Models;

namespace TollSystem.Core.Services
{
    public interface ITollStationRepositoryService
    {
        public Tollstation FindById(int id);

        public List<Tollstation> FindAll();
    }
}