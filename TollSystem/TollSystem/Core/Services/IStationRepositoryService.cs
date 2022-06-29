using TollSystem.Infrastructure.Models;

namespace TollSystem.Core.Services
{
    public interface IStationRepositoryService
    {
        public Tollstation FindById(int id);
    }
}