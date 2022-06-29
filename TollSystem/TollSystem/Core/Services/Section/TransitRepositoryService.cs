using System;
using System.Collections.Generic;
using System.Text;
using TollSystem.Infrastructure.Models;
using TollSystem.Infrastructure.Repositories;

namespace TollSystem.Core.Services
{
    public class TransitRepositoryService : RepositoryService<Transit>, ITransitRepositoryService
    {
        public TransitRepositoryService(IRepository<Transit> repository) : base(repository)
        {

        }
    }
}
