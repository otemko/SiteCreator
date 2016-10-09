using SiteCreator.ORM;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SiteCreator.Entities;
using SiteCreator.DAL.IRepository;

namespace SiteCreator.DAL.Repository
{
    public class SearchRepository : ISearchRepository
    {
        private SiteCreatorDbContext context;
        public SearchRepository(SiteCreatorDbContext context)
        {
            this.context = context;
        }

        public ICollection<Page> GetPagesByComment(string searchTerm)
        {
            return context.Set<Page>().FromSql("dbo.SearchComment {0}", searchTerm).ToList();
        }

        public ICollection<Page> GetPagesByContent(string searchTerm)
        {
            return context.Set<Page>().FromSql("dbo.SearchPageContent {0}", searchTerm).ToList();
        }

        public ICollection<Site> GetSitesBySiteName(string searchTerm)
        {
            return context.Set<Site>().FromSql("dbo.SearchSiteName {0}", searchTerm).ToList();
        }

        public ICollection<Site> GetSitesByTagName(string searchTerm)
        {
            return context.Set<Site>().FromSql("dbo.SearchTagName {0}", searchTerm).ToList();
        }

        public ICollection<User> GetUsersByUserName(string searchTerm)
        {
            return context.Set<User>().FromSql("dbo.SearchUserName {0}", searchTerm).ToList();
        }
    }
}
