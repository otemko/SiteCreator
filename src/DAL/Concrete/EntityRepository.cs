using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.DTO;
using ORM;
using DAL.Mapper;
using ORM.Model;

namespace DAL.Concrete
{
    public class EntityRepository<TEntity, TDal> : IEntityRepository<TDal>
        where TDal : class, IDalEntity
        where TEntity : class, new()
    {
        private SiteCreatorDbContext context;
        private readonly IMapper<TEntity, TDal> mapper;

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
            context.Set<TEntity>().Add(mapper.ToDataBase(entity));
        }

        public void Update(TDal entity)
        {
            context.Set<TEntity>().Update(mapper.ToDataBase(entity));
        }

        public virtual void Delete(TDal entity)
        {
            context.Set<TEntity>().Remove(mapper.ToDataBase(entity));
        }

        public virtual IEnumerable<TDal> AllIncluding(params Expression<Func<TDal, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = context.Set<TEntity>();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(mapper.ToDataBaseExpressionInclude(includeProperty));
            }
            return query.AsEnumerable().Select(x => mapper.ToDal(x));
        }

        public virtual async Task<IEnumerable<TDal>> AllIncludingAsync(params Expression<Func<TDal, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = context.Set<TEntity>();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(mapper.ToDataBaseExpressionInclude(includeProperty));
            }
            return await query.Select(x => mapper.ToDal(x)).ToListAsync();
        }

        public virtual IEnumerable<TDal> FindBy(Expression<Func<TDal, bool>> predicate)
        {
            return context.Set<TEntity>()
                .Where(mapper.ToDataBaseExpression(predicate))
                .Select(x => mapper.ToDal(x));
        }

        public virtual async Task<IEnumerable<TDal>> FindByAsync(Expression<Func<TDal, bool>> predicate)
        {
            return await context.Set<TEntity>()
                .Where(mapper.ToDataBaseExpression(predicate))
                .Select(x => mapper.ToDal(x))
                .ToListAsync();
        }

        public virtual IEnumerable<TDal> GetAll()
        {
            return context.Set<TEntity>().AsEnumerable().Select(x => mapper.ToDal(x));
        }

        public virtual async Task<IEnumerable<TDal>> GetAllAsync()
        {
            return await context.Set<TEntity>().Select(x => mapper.ToDal(x)).ToListAsync();
        }

        public virtual TDal GetSingle(Expression<Func<TDal, bool>> predicate)
        {
            return context.Set<TEntity>()
                .Where(mapper.ToDataBaseExpression(predicate))
                .Select(x => mapper.ToDal(x)).FirstOrDefault();
        }

        public virtual TDal GetSingle(int id)
        {
            return context.Set<TEntity>().Select(x => mapper.ToDal(x)).FirstOrDefault(e => e.Id == id);
        }

        public virtual TDal GetSingle(Expression<Func<TDal, bool>> predicate, params Expression<Func<TDal, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = context.Set<TEntity>();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(mapper.ToDataBaseExpressionInclude(includeProperty));
            }

            return query.Where(mapper.ToDataBaseExpression(predicate)).Select(x => mapper.ToDal(x)).FirstOrDefault();
        }

        public virtual async Task<TDal> GetSingleAsync(int id)
        {
            return await context.Set<TEntity>().Select(x => mapper.ToDal(x)).
                FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<IEnumerable<TDal>>  GetAllAsync(Expression<Func<TDal, bool>> predicate)
        {
            return await context.Set<TEntity>().
                Where(mapper.ToDataBaseExpression(predicate)).
                Select(x => mapper.ToDal(x)).
                ToListAsync();
        }
    }
}
