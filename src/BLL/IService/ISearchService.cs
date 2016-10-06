using SiteCreator.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteCreator.BLL.IService
{
    public interface ISearchService
    {
        ICollection<Tag> GetTagsIdByTagName(string searchTerm);
        ICollection<Site> GetSitesIdBySiteName(string searchTerm);
        ICollection<User> GetUsersIdByNick(string searchTerm);
    }
}
