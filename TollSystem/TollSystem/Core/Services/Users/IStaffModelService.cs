using TollSystem.Core.Entities;
using TollSystem.Infrastructure.Models;

namespace TollSystem.Core.Services
{
    public interface IStaffModelService
    {
        public StaffEntity ModelToEntity(Staff s);
    }
}