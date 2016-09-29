using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SiteCreator.Entities;
using SiteCreator.DAL;
using SiteCreator.BLL.IService;
using System;

namespace SiteCreator.BLL.Services
{
    public class SiteService : EntityService<Site,int>,  ISiteService
    {
        IEntityRepository repository;

        public SiteService(IEntityRepository repository): base(repository)
        {
            this.repository = repository;            
        }

        public async Task<IEnumerable<Site>> GetAllSitesWithUserAndTag()
        {
            var result = new List<Site>();

            var tagsites = await repository.AllIncludingAsync<TagSite>(ts => ts.Site, ts => ts.Site.User, ts => ts.Tag);

            foreach (var tagsite in tagsites)
            {
                if (!result.Contains(tagsite.Site))
                {
                    result.Add(tagsite.Site);
                }
            }

            return result;
        }

        public async Task<IEnumerable<Site>> GetSitesByTagId(int tagId)
        {
            var result = new List<Site>();

            var tagsitesese = new List<TagSite>();

            var tagsites = await repository.GetAllAsync<TagSite>(ts => ts.TagId == tagId);
            foreach (var item in tagsites)
            {
                tagsitesese.AddRange(await repository.GetAllAsync<TagSite>(ts => ts.SiteId == item.SiteId, 
                    ts => ts.Site, ts => ts.Site.User, ts => ts.Tag));
            }
            

            foreach (var tagsite in tagsitesese)
            {
                if (!result.Contains(tagsite.Site))
                {
                    result.Add(tagsite.Site);
                }
            }

            return result;
        }

        public async Task<IEnumerable<Site>> GetSitesByUserId(string userId)
        {
            var result = new List<Site>();

            var tagsites = await repository.GetAllAsync<TagSite>(ts => ts.Site.UserId == userId,
                ts=> ts.Site, ts => ts.Site.User, ts => ts.Tag);

            foreach (var tagsite in tagsites)
            {
                if (!result.Contains(tagsite.Site))
                {
                    result.Add(tagsite.Site);
                }
            }

            return result;
        }
    }
}
