using System;
using System.Collections.Generic;
using System.Text;
using TollSystem.Infrastructure.Models;
using TollSystem.Infrastructure.Repositories;

namespace TollSystem.Core.Services
{
    class PriceRepositoryService : RepositoryService<Price>, IPriceRepositoryService
    {
        private IPriceRepository _repository;
        public PriceRepositoryService(IPriceRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public List<Price> FindByPricelistAndSectionId(int pricelistId, int sectionId)
        {
            return _repository.FindByPricelistAndSectionId(pricelistId, sectionId);
        }

        public List<Price> FindByPricelistId(int id)
        {
            return _repository.FindByPricelistId(id);
        }
    }
}
