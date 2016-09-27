using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SiteCreator.ORM;
using SiteCreator.Entities;
using Microsoft.EntityFrameworkCore;

namespace SiteCreator.DAL
{
    public class EntityRepository : IEntityRepository
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

        public virtual void Create<T>(T entity) where T : class
        {
            context.Add(entity);
        }

        public virtual void Update<T>(T entity) where T : class
        {
            context.Update(entity);
        }

        public virtual void Delete<T>(T entity) where T : class
        {
            context.Remove(entity);
        }

        public virtual IEnumerable<T> AllIncluding<T>(params Expression<Func<T,
            object>>[] includeProperties) where T : class
        {
            IQueryable<T> query = context.Set<T>();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query.AsEnumerable();
        }

        public virtual async Task<IEnumerable<T>> AllIncludingAsync<T>(params Expression<Func<T,
            object>>[] includeProperties) where T : class
        {
            IQueryable<T> query = context.Set<T>();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return await query.ToListAsync();
        }

        public virtual IEnumerable<T> FindBy<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return context.Set<T>()
                .Where(predicate);
        }

        public virtual async Task<IEnumerable<T>> FindByAsync<T>(Expression<Func<T,
            bool>> predicate) where T : class
        {
            return await context.Set<T>()
                .Where(predicate).ToListAsync();
        }

        public virtual IEnumerable<T> GetAll<T>() where T : class
        {
            return context.Set<T>().AsEnumerable();
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync<T>() where T : class
        {
            return await context.Set<T>().ToListAsync();
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return await context.Set<T>().Where(predicate).ToListAsync();
        }

        public virtual T GetSingle<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return context.Set<T>()
                .Where(predicate).FirstOrDefault();
        }

        public virtual T GetSingle<T, Q>(Q id) where T : class, WithId<Q>
        {
            return context.Set<T>().FirstOrDefault(e => e.Id.Equals(id));
        }

        public async Task<T> GetSingleAsync<T, Q>(Q id) where T : class, WithId<Q>
        {
            return await context.Set<T>().FirstOrDefaultAsync(e => e.Id.Equals(id));
        }

        public virtual T GetSingle<T>(Expression<Func<T, bool>> predicate,
            params Expression<Func<T, object>>[] includeProperties) where T : class
        {
            IQueryable<T> query = context.Set<T>();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return query.Where(predicate).FirstOrDefault();
        }

        
    }
}
