using System.Collections.Generic;
using TollSystem.Core.Entities;
using TollSystem.Infrastructure.Models;

namespace TollSystem.Core.Services
{
    public interface IStaffRepositoryService
    {
        public StaffEntity FindByCredentials(string username, string password);

        public Staff FindMasterByStation(int id);
    }
}