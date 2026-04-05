using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core.DataAccess
{
    public class EntityRepository<TEntity, TContext> : IEntityRepository<TEntity>
       where TEntity : class, IEntity, new()
       where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            using var ctx = new TContext();
            ctx.Entry(entity).State = EntityState.Added;
            ctx.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            using var ctx = new TContext();
            ctx.Entry(entity).State = EntityState.Modified;
            ctx.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            using var ctx = new TContext();
            ctx.Entry(entity).State = EntityState.Deleted;
            ctx.SaveChanges();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using var ctx = new TContext();
            return ctx.Set<TEntity>().SingleOrDefault(filter);
        }

        public IList<TEntity> GetAll(Expression<Func<TEntity, bool>>? filter = null)
        {
            using var ctx = new TContext();
            var set = ctx.Set<TEntity>();
            return filter == null ? set.ToList() : set.Where(filter).ToList();
        }
    }
}
