using System;
using System.Collections.Generic;
using System.Text;
using TollSystem.Infrastructure.Models;
using TollSystem.Infrastructure.Repositories;

namespace TollSystem.Core.Services
{
    public class TollStationRepositoryService : RepositoryService<Tollstation>, ITollStationRepositoryService
    {
        public TollStationRepositoryService(IRepository<Tollstation> repository) : base(repository)
        {
        }
    }
}
