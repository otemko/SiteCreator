using DAL.Interfaces;
using DAL.ORM.Model;
using DAL.ORM;

namespace DAL.Concrete
{
    public class SiteRepository : EntityRepository<Site>, ISiteRepository
    {
        public SiteRepository(SiteCreatorDbContext context) : base(context)
        {
        }
    }
}
