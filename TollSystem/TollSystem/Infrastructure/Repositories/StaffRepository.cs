using System.Collections.Generic;
using System.Linq;
using TollSystem.Infrastructure.Models;

namespace TollSystem.Infrastructure.Repositories
{
    public class StaffRepository : Repository<Staff>, IStaffRepository
    {
        public StaffRepository(ModelContext m) : base(m, m.Staff)
        {
        }


        public List<Staff> FindByStationId(int id)
        {
            List<Staff> staff = _table.Where(s => s.Stationid == id).ToList();

            return staff;
        }

        public Staff FindByCredentials(string username, string password)
        {
            List<Staff> staff = _table.Where(s => s.Username == username && s.Password == password).ToList();
            if (staff.Count >= 1)
            {
                return staff[0];
            }

            return null;
        }
    }
}