using SiteCreator.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SiteCreator.BLL.IService
{
    public interface IPageService : IEntityService<Page, int>
    {
        Task<Page> GetPageWithUserAndContentAndComments(int id);
        Task<Page> GetPageWithSiteAndContent(int id);
        Task<Page> GetPageWithSite(int id);
    }
}
