using DAL.Interfaces;


namespace DAL.Concrete
{
    public class AchievementRepository : EntityRepository<Achievement>, IAchievementRepository
    {
        public AchievementRepository(SiteCreatorDbContext context) : base(context)
        {
        }
    }
}
