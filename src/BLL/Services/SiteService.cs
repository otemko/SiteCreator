﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SiteCreator.Entities;
using SiteCreator.DAL;

namespace SiteCreator.BLL.Services
{
    public class SiteService
    {
        IEntityRepository repository;

        public SiteService(IEntityRepository repository)
        {
            this.repository = repository;
        }

        public void CreateAsync(Site site)
        {
            repository.Create(site);
            repository.Commit();
        }

        public void Update(Site site)
        {
            repository.Update(site);
            repository.Commit();
        }

        public void Delete(Site site)
        {
            repository.Delete(site);
            repository.Commit();
        }

        public async Task<IEnumerable<Site>> GetAllByUserAsync(string userId)
        {
            var sites = await repository.GetAllAsync<Site>(p => p.UserId == userId);
            return sites;
        }

    }
}
