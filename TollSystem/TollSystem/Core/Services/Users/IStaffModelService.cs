using TollSystem.Core.Entities;
using TollSystem.Infrastructure.Models;

namespace TollSystem.Core.Services.Users
{
    public interface IStaffModelService
    {
        public StaffEntity ModelToEntity(Staff s);
    }
}