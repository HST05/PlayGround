using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Core.DataAccess.EntityFramework
{
    public class EFEntityRepositoryBase<TContext, TEntity> : IEntityRepository<TEntity>
        where TContext : DbContext, new()
        where TEntity : class, IEntity, new()
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
        using (TContext context = new TContext())
        {
            return context.Set<TEntity>().ToList();
        }
    }

    public void Update(TEntity entity)
    {
        throw new NotImplementedException();
    }
    }
}
