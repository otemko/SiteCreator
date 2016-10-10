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

        Task<IEnumerable<Page>> GetMostCommentedPages(int take = 0, int skip = 0);
        Task<IEnumerable<Page>> GetMostRatedPages(int take = 0, int skip = 0);
        Task Vote(Page page, int rating);
    }
}
