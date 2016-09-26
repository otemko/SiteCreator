using BLL.Mappers;
using BLL.Model;
using DAL.Interfaces;
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

        public void CreateAsync(BllSite site)
        {
            repository.Create(site.ToDal());
            repository.Commit();
        }

        public void Update(BllSite site)
        {
            repository.Update(site.ToDal());
            repository.Commit();
        }

        public void Delete(BllSite site)
        {
            repository.Delete(site.ToDal());
            repository.Commit();
        }

        public async Task<IEnumerable<BllSite>> GetAllByUserAsync(string userId)
        {
            var sites = await repository.GetAllAsync(p => p.UserId == userId);
            return sites.Select(p => p.ToBll());
        }
    }
}
