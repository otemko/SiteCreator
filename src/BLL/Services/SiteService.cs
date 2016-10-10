using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SiteCreator.Entities;
using SiteCreator.DAL;
using SiteCreator.BLL.IService;
using System;
using SiteCreator.DAL.Repository;
using SiteCreator.DAL.IRepository;

namespace SiteCreator.BLL.Services
{
    public class SiteService : EntityService<Site,int>,  ISiteService
    {
        IEntityRepository repository;
        ISiteRepository siteRepository;

        public SiteService(IEntityRepository repository, ISiteRepository siteRepository): base(repository)
        {
            this.siteRepository = siteRepository;
            this.repository = repository;            
        }

        public async Task<IEnumerable<Site>> GetAllSitesWithUserAndTag()
        {
            var sites = await siteRepository.GetSitesIncludeAllBy();
            return sites;
        }

        public async Task<Site> GetSitesById(int siteId)
        {
            var sites = await siteRepository.GetSitesIncludeAllBy(0, 0, p => p.Id == siteId);
            return sites.FirstOrDefault();
        }

        public async Task<IEnumerable<Site>> GetSitesByTagId(int tagId)
        {
            var sites = await siteRepository.GetSitesIncludeAllBy(0, 0, p => p.TagSite.Any(q => q.TagId == tagId));
            return sites;
        }

        public async Task<IEnumerable<Site>> GetSitesByUserId(string userId)
        {
            var sites = await siteRepository.GetSitesIncludeAllBy(0, 0, p => p.UserId == userId);
            return sites;
        }

        public async Task CreateSiteWithTagsAsync(Site site, List<Tag> tags)
        {
            FillTagsToSite(site, tags);
            await repository.CreateAsync(site);
        }

        public async Task UpdateSiteWithTagsAsync(Site site, List<Tag> tags)
        {
            FillTagsToSite(site, tags);
            await repository.UpdateAsync(site);
        }

        void FillTagsToSite(Site site, List<Tag> tags)
        {
            site.TagSite = new List<TagSite>();
            tags.ForEach(p => site.TagSite.Add(new TagSite { Site = site, Tag = p }));
        }

        public async Task<IEnumerable<Site>> GetLastCreatedSites(int take = 0, int skip = 0)
        {
            return await siteRepository.GetSitesIncludeAllOrderBy(true, p => p.DateCreated, take, skip);
        }
    }
}
