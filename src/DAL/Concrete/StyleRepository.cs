using DAL.Interfaces;
using DAL.ORM.Model;
using DAL.ORM;

namespace DAL.Concrete
{
    public class StyleRepository : EntityRepository<Style>, IStyleRepository
    {
        public StyleRepository(SiteCreatorDbContext context) : base(context)
        {
        }
    }
}
