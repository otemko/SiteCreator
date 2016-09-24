using DAL.Interfaces;
using DAL.ORM.Model;
using DAL.ORM;

namespace DAL.Concrete
{
    public class AchievementRepository : EntityRepository<Achievement>, IAchievementRepository
    {
        public AchievementRepository(SiteCreatorDbContext context) : base(context)
        {
        }
    }
}
