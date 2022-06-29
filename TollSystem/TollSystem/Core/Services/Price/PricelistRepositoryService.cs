using System;
using System.Collections.Generic;
using System.Text;
using TollSystem.Core.Entities;
using TollSystem.Infrastructure.Models;
using TollSystem.Infrastructure.Repositories;

namespace TollSystem.Core.Services
{
    public class PricelistRepositoryService : RepositoryService<Pricelist>, IPricelistRepositoryService
    {
        private IPricelistRepository _repository;

        public PricelistRepositoryService(IPricelistRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public Pricelist FindActive()
        {
            return _repository.FindActive();
        }
    }
}
