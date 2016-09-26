using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.DTO;
using ORM;

namespace DAL.Concrete
{
    public class EntityRepository<TEntity, TDal> : IEntityRepository<TDal> 
        where TDal : class, IDalEntity, new()
        where TEntity : class, new()
    {
        private SiteCreatorDbContext context;

        public EntityRepository(SiteCreatorDbContext context)
        {
            this.context = context;
        }

        public virtual void Commit()
        {
            context.SaveChanges();
        }

        public virtual void Create(TDal entity)
        {
            context.Set<TEntity>().Add(entity);
        }

        public void Update(TDal entity)
        {
            context.Set<T>().Update(entity);
        }

        public virtual void Delete(TDal entity)
        {
            context.Set<T>().Remove(entity);
        }

        public virtual IEnumerable<TDal> AllIncluding(params Expression<Func<TDal, object>>[] includeProperties)
        {
            IQueryable<T> query = context.Set<T>();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query.AsEnumerable();
        }

        public virtual async Task<IEnumerable<TDal>> AllIncludingAsync(params Expression<Func<TDal, object>>[] includeProperties)
        {
            IQueryable<T> query = context.Set<T>();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return await query.ToListAsync();
        }

        public virtual IEnumerable<TDal> FindBy(Expression<Func<TDal, bool>> predicate)
        {
            return context.Set<T>().Where(predicate);
        }

        public virtual async Task<IEnumerable<TDal>> FindByAsync(Expression<Func<TDal, bool>> predicate)
        {
            return await context.Set<T>().Where(predicate).ToListAsync();
        }

        public virtual IEnumerable<TDal> GetAll()
        {
            return context.Set<T>().AsEnumerable();
        }

        public virtual async Task<IEnumerable<TDal>> GetAllAsync()
        {
            return await context.Set<T>().ToListAsync();
        }

        public virtual TDal GetSingle(Expression<Func<TDal, bool>> predicate)
        {
            return context.Set<T>().FirstOrDefault(predicate);
        }

        public virtual TDal GetSingle(int id)
        {
            return context.Set<T>().FirstOrDefault(e => e.Id == id);
        }

        public virtual TDal GetSingle(Expression<Func<TDal, bool>> predicate, params Expression<Func<TDal, object>>[] includeProperties)
        {
            IQueryable<T> query = context.Set<T>();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return query.Where(predicate).FirstOrDefault();
        }

        public virtual async Task<TDal> GetSingleAsync(int id)
        {
            return await context.Set<T>().FirstOrDefaultAsync(e => e.Id == id);
        }                
    }
}
