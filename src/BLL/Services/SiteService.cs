using BLL.Model;
using DAL.Interfaces;
using DAL.ORM.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class SiteService
    {
        ISiteRepository repository;

        public SiteService(ISiteRepository repository)
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

        public async Task<IEnumerable<BllSite>> GetAllByUserAsync(string userId)
        {
            var sites = await repository.GetAllAsync(p => p.UserId == userId);
            return sites.Select(p => p.ToBll());
        }

    }
}
