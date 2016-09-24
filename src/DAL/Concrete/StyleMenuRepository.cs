using DAL.Interfaces;
using DAL.ORM.Model;
using DAL.ORM;


namespace DAL.Concrete
{
    public class StyleMenuRepository : EntityRepository<StyleMenu>, IStyleMenuRepository
    {
        public StyleMenuRepository(SiteCreatorDbContext context) : base(context)
        {
        }
    }
}
