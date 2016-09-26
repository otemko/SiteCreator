using DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IEntityRepository<TDal> where TDal : IDalEntity
    {
        IEnumerable<TDal> AllIncluding(params Expression<Func<TDal, object>>[] includeProperties);
        Task<IEnumerable<TDal>> AllIncludingAsync(params Expression<Func<TDal, object>>[] includeProperties);

        IEnumerable<TDal> GetAll();
        Task<IEnumerable<TDal>> GetAllAsync();
        Task<IEnumerable<TDal>> GetAllAsync(Expression<Func<TDal, bool>> predicate);

        TDal GetSingle(int id);
        TDal GetSingle(Expression<Func<TDal, bool>> predicate);
        TDal GetSingle(Expression<Func<TDal, bool>> predicate, params Expression<Func<TDal, object>>[] includeProperties);
        Task<TDal> GetSingleAsync(int id);

        IEnumerable<TDal> FindBy(Expression<Func<TDal, bool>> predicate);
        Task<IEnumerable<TDal>> FindByAsync(Expression<Func<TDal, bool>> predicate);

        void Create(TDal entity);
        void Delete(TDal entity);
        void Update(TDal entity);

        void Commit();
    }
}
