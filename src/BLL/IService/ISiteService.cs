using SiteCreator.BLL.Services;
using SiteCreator.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteCreator.BLL.IService
{
    public interface ISiteService<T,Q>: IEntityService<T,Q>
    {
        Task<IEnumerable<Site>> GetSitesWithUser(string userId);
    }
}
