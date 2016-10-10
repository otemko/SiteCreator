using SiteCreator.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SiteCreator.DAL.IRepository
{
    public interface ISiteRepository
    {
        Task<IEnumerable<Site>> GetSitesIncludeAllBy
            (int take = 0, int skip = 0, Expression<Func<Site, bool>> predicate = null);

        Task<IEnumerable<Site>> GetSitesIncludeAllOrderBy<TKey>
            (bool orderByDescending, Expression<Func<Site, TKey>> predicateOrder = null,
                int take = 0, int skip = 0, Expression<Func<Site, bool>> predicate = null);
    }
}
