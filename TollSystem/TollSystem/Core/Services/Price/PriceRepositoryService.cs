using System;
using System.Collections.Generic;
using System.Text;
using TollSystem.Infrastructure.Models;
using TollSystem.Infrastructure.Repositories;

namespace TollSystem.Core.Services
{
    class PriceRepositoryService : RepositoryService<Price>
    {
        public PriceRepositoryService(IRepository<Price> repository) : base(repository)
        { }
    }
}
