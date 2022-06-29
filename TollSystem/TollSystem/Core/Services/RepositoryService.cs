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

        public void Add(T obj)
        {
            _repository.Add(obj);
        }

        public void Delete(object id)
        {
            _repository.Delete(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _repository.GetAll();
        }

        public T GetById(object id)
        {
            return _repository.GetById(id);
        }

        public void Save()
        {
            _repository.Save();
        }

        public void Update(T obj)
        {
            _repository.Update(obj);
        }
    }
}
