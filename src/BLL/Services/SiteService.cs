using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SiteCreator.Entities;
using SiteCreator.DAL;
using SiteCreator.BLL.IService;

namespace SiteCreator.BLL.Services
{
    public class SiteService : EntityService<Site,int>,  ISiteService
    {
        IEntityRepository repository;

        public SiteService(IEntityRepository repository): base(repository)
        {
            this.repository = repository;            
        }
        
        public async Task<IEnumerable<Site>> GetSitesWithUserAndTag(string userId)
        {
            var result = new List<Site>();

            var tagsites = await repository.GetAllAsync<TagSite>(ts => ts.Site.UserId == userId, 
                ts => ts.Site, ts => ts.Site.User, ts => ts.Tag);

            foreach (var tagsite in tagsites)
            {
                if (!result.Contains(tagsite.Site))
                {
                    result.Add(tagsite.Site);
                }
            }

            return result;
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
    }
}
