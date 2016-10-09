using SiteCreator.DAL.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Threading.Tasks;
using SiteCreator.Entities;
using SiteCreator.ORM;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace SiteCreator.DAL.Repository
{
    public class SiteRepository : ISiteRepository
    {
        private SiteCreatorDbContext context;

        public SiteRepository(SiteCreatorDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Site>> GetSitesIncludeAllBy
            (Expression<Func<Site, bool>> predicate =null, int take = 0, int skip = 0)
        {
            return await GetAllQuery(predicate, take, skip).ToListAsync();
        }

        public async Task<IEnumerable<Site>> GetSitesIncludeAllAndPagesBy
            (Expression<Func<Site, bool>> predicate = null, int take = 0, int skip = 0)
        {
            return await GetAllQuery(predicate, take, skip).Include(p => p.Page).ToListAsync();
        }

        public IQueryable<Site> GetAllQuery(Expression<Func<Site, bool>> predicate = null, int take = 0, int skip = 0)
        {
            var res = IncludeAll(Skipping(take, skip));
            if (predicate != null) res = res.Where(predicate);
            return res;
        }

        public IQueryable<Site> IncludeAll(IQueryable<Site> sites)
        {
            return sites.Include(p => p.User).Include(p => p.TagSite).ThenInclude(p => p.Tag);
        }

        public IQueryable<Site> Skipping(int take, int skip)
        {
            var sites = context.Site;
            if (take != 0) sites.Take(take);
            if (skip != 0) sites.Skip(skip);
            return sites;
        }
    }
}
