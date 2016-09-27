using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SiteCreator.Entities;
using SiteCreator.DAL;
using SiteCreator.BLL.IService;

namespace SiteCreator.BLL.Services
{
    public class SiteService : ISiteService
    {
        IEntityRepository repository;

        public SiteService(IEntityRepository repository)
        {
            this.repository = repository;
        }

        public void CreateAsync(Site site)
        {
            repository.Create(site);
            repository.CommitAsync();
        }

        public void Update(Site site)
        {
            repository.Update(site);
            repository.CommitAsync();
        }

        public void Delete(Site site)
        {
            repository.Delete(site);
            repository.CommitAsync();
        }

        public async Task<IEnumerable<Site>> GetAllByUserAsync(string userId)
        {
            var sites = await repository.GetAllAsync<Site>(p => p.UserId == userId);
            return sites;
        }

    }
}
