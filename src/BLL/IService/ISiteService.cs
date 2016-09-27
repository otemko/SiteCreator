using SiteCreator.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SiteCreator.BLL.IService
{
    public interface ISiteService: IEntityService<Site,int>
    {
        Task<IEnumerable<Site>> GetSitesWithUser(string userId);
    }
}
