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

        public async Task<IEnumerable<Site>> GetSitesIncludeAllOrderBy<TKey>
            (bool orderByDescending, Expression<Func<Site, TKey>> predicateOrder,
                int take = 0, int skip = 0, Expression<Func<Site, bool>> predicate = null)
        {
            var res = GetAllQuery(take, skip, predicate);
            if (orderByDescending) res = res.OrderByDescending(predicateOrder);
            else res = res.OrderBy(predicateOrder);

            return await res.ToListAsync();
        }

        public async Task<IEnumerable<Site>> GetSitesIncludeAllBy
            (int take = 0, int skip = 0, Expression<Func<Site, bool>> predicate = null)
        {
            return await GetAllQuery(take, skip, predicate).ToListAsync();
            
        }

        public IQueryable<Site> GetAllQuery(int take = 0, int skip = 0, Expression<Func<Site, bool>> predicate = null)
        {
            var res = IncludeAll(Skipping(take, skip));
            if (predicate != null) res = res.Where(predicate);
            return res;
        }

        public IQueryable<Site> IncludeAll(IQueryable<Site> sites)
        {
            return sites.Include(p => p.User).Include(p => p.Page).Include(p => p.TagSite).ThenInclude(p => p.Tag);
        }

        public IQueryable<Site> Skipping(int take, int skip)
        {
            var sites = context.Site;
            IQueryable<Site> query = sites;
            if (take != 0) query = sites.Take(take);
            if (skip != 0) query = sites.Skip(skip);
            return query;
        }
    }
}
