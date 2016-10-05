using SiteCreator.BLL.IService;
using SiteCreator.DAL;
using SiteCreator.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteCreator.BLL.Services
{
    public abstract class EntityService<T,Q> where T : class, WithId<Q>
    {
        IEntityRepository repository;

        public EntityService(IEntityRepository repository)
        {
            this.repository = repository;
        }

        public virtual async Task CreateAsync(T entity)
        {
            await repository.CreateAsync<T>(entity);
        }

        public virtual async Task CreateRangeAsync(T[] entities)
        {
            await repository.CreateRangeAsync<T>(entities);
        }

        public virtual async Task UpdateAsync(T entity)
        {
            await repository.Update<T>(entity);
        }

        public virtual async Task DeleteAsync(T entity)
        {
            await repository.Delete<T>(entity);
        }

        public virtual async Task DeleteRangeAsync(T[] entities)
        {
            await repository.DeleteRange<T>(entities);
        }
        public virtual Task<IEnumerable<T>> GetAllAsync()
        {
            return repository.GetAllAsync<T>();
        }

        public async Task<T> GetSingleAsync(Q Id)
        {
            var result = await repository.GetSingleAsync<T, Q>(Id);
            return result;
        }
    }
}
