using SiteCreator.DAL.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SiteCreator.Entities;
using SiteCreator.ORM;

namespace SiteCreator.DAL.Repository
{
    public class SiteRepository : ISiteRepository
    {
        private SiteCreatorDbContext context;

        public SiteRepository(SiteCreatorDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Site> GetAllSitesWithUsersAndTagsByTagId(int tagId)
        {
            var sites = from site in context.Site
                        where site.TagSite.Any(p => p.TagId == tagId)
                        select site;
            return sites.ToList();
        }
    }
}
