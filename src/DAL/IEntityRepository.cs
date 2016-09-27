using SiteCreator.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SiteCreator.DAL
{
    public interface IEntityRepository
    {
        IEnumerable<T> AllIncluding<T>(params Expression<Func<T, object>>[] includeProperties) where T : class;
        Task<IEnumerable<T>> AllIncludingAsync<T>(params Expression<Func<T, object>>[] includeProperties) where T : class;

        IEnumerable<T> GetAll<T>() where T : class;
        Task<IEnumerable<T>> GetAllAsync<T>() where T : class;
        Task<IEnumerable<T>> GetAllAsync<T>(Expression<Func<T, bool>> predicate) where T : class;

        T GetSingle<T, Q>(Q id) where T : class, WithId<Q>;
        T GetSingle<T>(Expression<Func<T, bool>> predicate) where T : class;
        T GetSingle<T>(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties) where T : class;
        Task<T> GetSingleAsync<T, Q>(Q id) where T : class, WithId<Q>;

        IEnumerable<T> FindBy<T>(Expression<Func<T, bool>> predicate) where T : class;
        Task<IEnumerable<T>> FindByAsync<T>(Expression<Func<T, bool>> predicate) where T : class;

        void Create<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;

        void Commit();
    }
}
