using DAL.Interfaces;
using DAL.ORM.Model;
using DAL.ORM;

namespace DAL.Concrete
{
    public class AchievementUserRepository : EntityRepository<AchievementUser>, IAchievementUserRepository
    {
        public AchievementUserRepository(SiteCreatorDbContext context) : base(context)
        {
        }
    }
}
