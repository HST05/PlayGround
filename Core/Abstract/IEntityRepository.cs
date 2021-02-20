using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Abstract
{
    public interface IEntityRepository<T>
    {
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        List<T> GetAll();
        List<T> Get();
    }
}
