using System;
using System.Collections.Generic;
using System.Text;
using TollSystem.Core.Services;
using TollSystem.Infrastructure.Models;
using TollSystem.Infrastructure.Repositories;

namespace TollSystem.Core.Services
{
    public class TollBoothRepositoryService : RepositoryService<Tollbooth>, ITollBoothRepositoryService
    {
        private ITollBoothRepository _repository;

        public TollBoothRepositoryService(ITollBoothRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public List<Tollbooth> FindByStationId(int id) 
        {
            return _repository.FindByStationId(id);    
        }

        public Tollbooth FindByStationIdAndOrdinalNumber(int id, int ordinalNumber) 
        {
            return _repository.FindByStationIdAndOrdinalNumber(id, ordinalNumber);
        }

    }
}
