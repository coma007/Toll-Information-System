using System.Collections.Generic;
using System.Windows.Documents;
using TollSystem.Infrastructure.Models;

namespace TollSystem.Infrastructure.Repositories
{
    public interface IStaffRepository : IRepository<Staff>
    {
        public List<Staff> FindByStationId(int id);

        public Staff FindByCredentials(string username, string password);
    }
}