using TollSystem.Infrastructure.Models;
using TollSystem.Infrastructure.Repositories;

namespace TollSystem.Core.Services
{
    public class StationRepositoryService : RepositoryService<Tollstation>, IStationRepositoryService
    {
        public StationRepositoryService(IRepository<Tollstation> repository) : base(repository)
        {
        }

        public Tollstation FindById(int id)
        {
            return _repository.GetById((decimal)id);
        }
    }
}