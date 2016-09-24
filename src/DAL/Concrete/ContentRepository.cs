using DAL.Interfaces;
using DAL.ORM.Model;
using DAL.ORM;


namespace DAL.Concrete
{
    public class ContentRepository : EntityRepository<Content>, IContentRepository
    {
        public ContentRepository(SiteCreatorDbContext context) : base(context)
        {
        }
    }
}
