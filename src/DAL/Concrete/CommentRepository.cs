using DAL.Interfaces;
using DAL.ORM.Model;
using DAL.ORM;

namespace DAL.Concrete
{
    public class CommentRepository : EntityRepository<Comment>, ICommentRepository
    {
        public CommentRepository(SiteCreatorDbContext context) : base(context)
        {
        }
    }
}
