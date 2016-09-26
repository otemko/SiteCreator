using DAL.DTO;

namespace DAL.Interfaces
{
    public interface IAchievementRepository : IEntityRepository<DalAchievement> { }
    public interface IAchievementUserRepository : IEntityRepository<DalAchievementUser> { }
    public interface ICommentRepository : IEntityRepository<DalComment> { }
    public interface IContentRepository : IEntityRepository<DalContent> { }
    public interface ILanguageRepository : IEntityRepository<DalLanguage> { }
    public interface ILayoutRepository : IEntityRepository<DalLayout> { }
    public interface IPageRepository : IEntityRepository<DalPage> { }
    public interface ISiteRepository : IEntityRepository<DalSite> { }
    public interface IStyleRepository : IEntityRepository<DalStyle> { }
    public interface IStyleMenuRepository : IEntityRepository<DalStyleMenu> { }
    public interface ITagRepository : IEntityRepository<DalTag> { }
    public interface ITagSiteRepository : IEntityRepository<DalTagSite> { }
}
