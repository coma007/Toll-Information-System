using System;
using System.Collections.Generic;
using System.Text;
using TollSystem.Infrastructure.Models;
using TollSystem.Infrastructure.Repositories;

namespace TollSystem.Core.Services
{
    public class TagRepositoryService : ITagRepositoryService
    {
        private IRepository<Tag> _repository;

        public TagRepositoryService(IRepository<Tag> repository)
        {
            _repository = repository;
        }
    }
}
