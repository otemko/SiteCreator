using DAL.Interfaces;
using DAL.ORM.Model;
using DAL.ORM;

namespace DAL.Concrete
{
    public class TagRepository : EntityRepository<Tag>, ITagRepository
    {
        public TagRepository(SiteCreatorDbContext context) : base(context)
        {
        }
    }
}
