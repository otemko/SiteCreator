using SiteCreator.BLL.IService;
using SiteCreator.DAL;
using SiteCreator.Entities;

namespace SiteCreator.BLL.Services
{
    public class StyleMenuService : EntityService<StyleMenu, int>, IStyleMenuService
    {
        IEntityRepository repository;

        public StyleMenuService(IEntityRepository repository): base(repository)
        {
            this.repository = repository;
        }
    }
}
