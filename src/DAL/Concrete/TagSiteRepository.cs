using DAL.Interfaces;
using DAL.ORM.Model;
using DAL.ORM;

namespace DAL.Concrete
{
    public class TagSiteRepository : EntityRepository<TagSite>, ITagSiteRepository
    {
        public TagSiteRepository(SiteCreatorDbContext context) : base(context)
        {
        }
    }
}
