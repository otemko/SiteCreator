using SiteCreator.BLL.IService;
using SiteCreator.DAL;
using SiteCreator.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteCreator.BLL.Services
{
    public class TagSiteService : EntityService<TagSite, int>, ITagSiteService
    {
        IEntityRepository repository;

        public TagSiteService(IEntityRepository repository) : base(repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<TagSite>> GetTagSitesBySiteId(int siteId)
        {
            var result = new List<TagSite>();

            return await repository.GetAllAsync<TagSite>(ts => ts.SiteId == siteId);            
        }
    }
}
