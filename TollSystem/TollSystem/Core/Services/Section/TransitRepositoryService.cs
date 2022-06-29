using System;
using System.Collections.Generic;
using System.Text;
using TollSystem.Infrastructure.Models;
using TollSystem.Infrastructure.Repositories;

namespace TollSystem.Core.Services
{
    public class TransitRepositoryService : RepositoryService<Transit>, ITransitRepositoryService
    {
        private ITransitRepository _repository;
        public TransitRepositoryService(ITransitRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public List<Transit> FindByStationAndDate(int id, DateTime startDate, DateTime endDate)
        {
            return _repository.FindByStationAndDate(id, startDate, endDate);
        }

        public Transit FindByTagId(int id)
        {
            return _repository.FindByTagId(id);
        }

        public Transit FindByTicketId(int id)
        {
            return _repository.FindByTicketId(id);
        }
    }
}
