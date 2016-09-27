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
        
        public async Task<IEnumerable<Site>> GetSitesWithUser(string userId)
        {
            var sites = await repository.GetAllAsync<Site>(s => s.UserId == userId, s => s.User);
            return sites;
        }

        public async Task<IEnumerable<Site>> GetSitesWithUserAndTag(string userId)
        {
            var sites = await repository.GetAllAsync<Site>(s => s.UserId == userId, s => s.User);
            return sites;
        }
    }
}
