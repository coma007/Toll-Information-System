using System;
using System.Collections.Generic;
using System.Text;
using TollSystem.Infrastructure.Models;
using TollSystem.Infrastructure.Repositories;

namespace TollSystem.Core.Services
{
    public class TollBoothRepositoryService : RepositoryService<Tollbooth>, ITollBoothRepositoryService
    {
        public TollBoothRepositoryService(IRepository<Tollbooth> repository) : base(repository)
        {
        }
    }
}
