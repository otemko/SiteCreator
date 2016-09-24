using DAL.Interfaces;
using DAL.ORM.Model;
using DAL.ORM;

namespace DAL.Concrete
{
    public class LayoutRepository : EntityRepository<Layout>, ILayoutRepository
    {
        public LayoutRepository(SiteCreatorDbContext context) : base(context)
        {
        }
    }
}
