using DAL.Interfaces;
using DAL.ORM.Model;
using DAL.ORM;


namespace DAL.Concrete
{
    public class LanguageRepository : EntityRepository<Language>, ILanguageRepository
    {
        public LanguageRepository(SiteCreatorDbContext context) : base(context)
        {
        }
    }
}
