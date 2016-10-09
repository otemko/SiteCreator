using SiteCreator.BLL.IService;
using SiteCreator.DAL.IRepository;
using SiteCreator.Entities;
using System.Collections.Generic;
using System;

namespace SiteCreator.BLL.Services
{
    public class SearchService : ISearchService
    {
        ISearchRepository repository;

        public SearchService(ISearchRepository repository)
        {
            this.repository = repository;
        }

        public ICollection<Page> GetPagesByComment(string searchTerm)
        {
            return repository.GetPagesByComment(searchTerm);
        }

        public ICollection<Page> GetPagesByContent(string searchTerm)
        {
            return repository.GetPagesByContent(searchTerm);
        }

        public ICollection<Site> GetSitesBySiteName(string searchTerm)
        {
            return repository.GetSitesBySiteName(searchTerm);
        }

        public ICollection<Site> GetSitesByTagName(string searchTerm)
        {
            return repository.GetSitesByTagName(searchTerm);
        }

        public ICollection<User> GetUsersByUserName(string searchTerm)
        {
            return repository.GetUsersByUserName(searchTerm);
        }

    }
}
