using SiteCreator.ORM;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SiteCreator.Entities;

namespace SiteCreator.DAL
{
    public class SearchRepository : ISearchRepository
    {
        private SiteCreatorDbContext context;
        public SearchRepository(SiteCreatorDbContext context)
        {
            this.context = context;
        }
        public ICollection<Site> GetSitesBySiteName(string searchTerm)
        {
            return context.Set<Site>().FromSql("dbo.SearchSiteName {0}", searchTerm).ToList();
        }

        public ICollection<Tag> GetTagsByTagName(string searchTerm)
        {
            return context.Set<Tag>().FromSql("dbo.SearchTagName {0}", searchTerm).ToList();            
        }

        public ICollection<User> GetUsersByNick(string searchTerm)
        {
            return context.Set<User>().FromSql("dbo.SearchUserName {0}", searchTerm).ToList();
        }
    }
}
