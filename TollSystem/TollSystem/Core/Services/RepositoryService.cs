using System;
using System.Collections.Generic;
using System.Text;
using TollSystem.Infrastructure.Repositories;

namespace TollSystem.Core.Services
{
    public class RepositoryService<T> : IRepositoryService<T> where T : class
    {
        protected IRepository<T> _repository;

        public RepositoryService(IRepository<T> repository)
        {
            _repository = repository;
        }
    }
}
