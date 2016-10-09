using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteCreator.BLL.IService
{
    public interface IEntityService<T,Q>
    {
        Task CreateAsync(T entity);
        Task CreateRangeAsync(T[] entities);
        Task UpdateAsync(T entity);
        Task UpdateRangeAsync(T[] entities);
        Task DeleteAsync(T entity);
        Task DeleteRangeAsync(T[] entities);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetSingleAsync(Q id);
    }
}
