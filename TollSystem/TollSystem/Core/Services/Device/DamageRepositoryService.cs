using System;
using System.Collections.Generic;
using System.Text;
using TollSystem.Infrastructure.Models;
using TollSystem.Infrastructure.Repositories;

namespace TollSystem.Core.Services
{
    public class DamageRepositoryService : RepositoryService<Damage>, IDamageRepositoryService
    {
        private IDamageRepository _repository;
        public DamageRepositoryService(IDamageRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public Damage FindByDeviceId(int id)
        {
            return _repository.FindByDeviceId(id);
        }
    }
}
