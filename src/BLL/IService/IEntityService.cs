using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteCreator.BLL.IService
{
    public interface IEntityService<T,Q>
    {
        void CreateAsync(T entity);
        void UpdateAsync(T entity);
        void DeleteAsync(T entity);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetSingleAsync(Q userId);
    }
}
