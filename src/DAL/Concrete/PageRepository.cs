using DAL.Interfaces;
using DAL.ORM.Model;
using DAL.ORM;

namespace DAL.Concrete
{
    public class PageRepository : EntityRepository<Page>, IPageRepository
    {
        public PageRepository(SiteCreatorDbContext context) : base(context)
        {
    }
}
}
