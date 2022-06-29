using System;
using System.Collections.Generic;
using System.Text;
using TollSystem.Infrastructure.Models;
using TollSystem.Infrastructure.Repositories;

namespace TollSystem.Core.Services
{
    public class DamageRepositoryService : RepositoryService<Damage>, IDamageRepositoryService
    {
        public DamageRepositoryService(IRepository<Damage> repository) : base(repository)
        {

        }
    }
}
