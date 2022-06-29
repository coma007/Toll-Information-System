using System.Collections.Generic;
using TollSystem.Core.Entities;

namespace TollSystem.Core.Services.Users
{
    public interface IStaffRepositoryService
    {
        public StaffEntity FindByCredentials(string username, string password);
    }
}