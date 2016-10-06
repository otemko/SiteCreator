using SiteCreator.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SiteCreator.DAL
{
    public interface IEntityRepository
    {
        Task<IEnumerable<T>> AllIncludingAsync<T>(params Expression<Func<T, object>>[] includeProperties) where T : class;

        Task<IEnumerable<T>> GetAllAsync<T>() where T : class;
        Task<IEnumerable<T>> GetAllAsync<T>(Expression<Func<T, bool>> predicate) where T : class;
        Task<IEnumerable<T>> GetAllAsync<T>(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties) where T : class;

        Task<T> GetSingleAsync<T>(Expression<Func<T, bool>> predicate) where T : class;
        Task<T> GetSingleAsync<T>(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties) where T : class;
        Task<T> GetSingleAsync<T, Q>(Q id) where T : class, WithId<Q>;
        
        Task<Q> CreateAsync<T,Q>(T entity) where T : class, WithId<Q>;
        Task CreateRangeAsync<T>(T[] entities) where T : class;
        Task DeleteAsync<T>(T entity) where T : class;
        Task DeleteRangeAsync<T>(T[] entities) where T : class;
        Task UpdateAsync<T>(T entity) where T : class;
        
    }
}
