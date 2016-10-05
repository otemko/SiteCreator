using SiteCreator.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SiteCreator.BLL.IService
{
    public interface IPageService : IEntityService<Page, int>
    {
        Task<Page> GetPageWithUserAndComments(int id);
    }
}
