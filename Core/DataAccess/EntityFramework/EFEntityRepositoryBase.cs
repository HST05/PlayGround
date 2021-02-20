using System;
using System.Collections.Generic;
using System.Text;
using Core.Abstract;

namespace Core.DataAccess.EntityFramework
{
    public class EFEntityRepositoryBase<TContext, TEntity> : IEntityRepository<TEntity>
    {
        public void Add(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public List<TEntity> Get()
        {
            throw new NotImplementedException();
        }

        public List<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
