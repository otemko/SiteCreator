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
            (Expression<Func<Site, bool>> predicate = null, int take = 0, int skip = 0);

        Task<IEnumerable<Site>> GetSitesIncludeAllAndPagesBy
            (Expression<Func<Site, bool>> predicate = null, int take = 0, int skip = 0);
    }
}
