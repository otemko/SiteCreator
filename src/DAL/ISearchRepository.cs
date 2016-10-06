using SiteCreator.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteCreator.DAL
{
    public interface ISearchRepository
    {
        ICollection<Tag> GetTagsByTagName(string searchTerm);
        ICollection<Site> GetSitesBySiteName(string searchTerm);
        ICollection<User> GetUsersByNick(string searchTerm);
    }
}
