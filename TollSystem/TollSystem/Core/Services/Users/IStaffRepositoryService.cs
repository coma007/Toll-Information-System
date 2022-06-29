using System.Collections.Generic;
using TollSystem.Core.Entities;

namespace TollSystem.Core.Services
{
    public interface IStaffRepositoryService
    {
        public StaffEntity FindByCredentials(string username, string password);
    }
}