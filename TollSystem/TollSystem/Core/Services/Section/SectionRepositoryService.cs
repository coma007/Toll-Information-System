using System;
using System.Collections.Generic;
using System.Text;
using TollSystem.Infrastructure.Models;
using TollSystem.Infrastructure.Repositories;

namespace TollSystem.Core.Services
{
    class SectionRepositoryService : RepositoryService<Section>, ISectionRepositoryService
    {
        public SectionRepositoryService(IRepository<Section> repository) : base(repository)
        { }
    }
}
