using System.Collections.Generic;
using System.Linq;
using TollSystem.Infrastructure.Models;
using TollSystem.Infrastructure.Repositories;

namespace TollSystem.Core.Services
{
    public class TollStationRepositoryService : RepositoryService<Tollstation>, ITollStationRepositoryService
    {
        public TollStationRepositoryService(IRepository<Tollstation> repository) : base(repository)
        {
        }

        public Tollstation FindById(int id)
        {
            return _repository.GetById((decimal)id);
        }

        public List<Tollstation> FindAll()
        {
            return _repository.GetAll().ToList();
        }
    }
}