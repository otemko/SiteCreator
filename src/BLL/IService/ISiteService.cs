using SiteCreator.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteCreator.BLL.IService
{
    public interface ISiteService
    {
        void CreateAsync(Site site);

        void Update(Site site);

        void Delete(Site site);

        Task<IEnumerable<Site>> GetAllByUserAsync(string userId);
    }
}
