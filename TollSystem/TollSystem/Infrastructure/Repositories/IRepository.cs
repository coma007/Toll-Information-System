using System;
using System.Collections.Generic;
using System.Text;

namespace TollSystem.Infrastructure.Repositories
{
    public interface IRepository<T> where T: class
    { 
        IEnumerable<T> GetAll();
        T GetById(object id);
        void Add(T obj);
        void Update(T obj);
        void Delete(object id);
        void Save();
    }
}
