using SiteCreator.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SiteCreator.BLL.IService
{
    public interface ISiteService: IEntityService<Site,int>
    {
        Task<IEnumerable<Site>> GetSitesByUserId(string userId);
        Task<IEnumerable<Site>> GetAllSitesWithUserAndTag();
        Task<IEnumerable<Site>> GetSitesByTagId(int tagId);
    }
}
