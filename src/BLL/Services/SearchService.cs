using SiteCreator.BLL.IService;
using SiteCreator.DAL;
using SiteCreator.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteCreator.BLL.Services
{
    public class SearchService : ISearchService
    {
        ISearchRepository repository;

        public SearchService(ISearchRepository repository)
        {
            this.repository = repository;
        }

        public ICollection<Site> GetSitesIdBySiteName(string searchTerm)
        {
            return repository.GetSitesBySiteName(searchTerm);
        }

        public ICollection<Tag> GetTagsIdByTagName(string searchTerm)
        {
            return repository.GetTagsByTagName(searchTerm);
        }

        public ICollection<User> GetUsersIdByNick(string searchTerm)
        {
            return repository.GetUsersByNick(searchTerm);
        }
    }
}
