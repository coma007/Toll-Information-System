using System.Collections.Generic;
using TollSystem.Core.Entities;
using TollSystem.Infrastructure.Repositories;

namespace TollSystem.Core.Services
{
    public interface IRepositoryService<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(object id);
        void Add(T obj);
        void Update(T obj);
        void Delete(object id);
        void Save();
    }
}