using DAL.Interfaces;
using ORM.Model;
using DAL.DTO;
using DAL.Mapper;
using System;
using System.Linq.Expressions;
using ORM;

namespace DAL.Concrete
{
    public class AchievementUserRepository : EntityRepository<AchievementUser, DalAchievementUser>,
        IAchievementUserRepository, IMapper<AchievementUser, DalAchievementUser>
    {
        private readonly IVisitor<AchievementUser, DalAchievementUser> visitorMapper;
        public AchievementUserRepository(SiteCreatorDbContext context) : base(context)
        {
        }

        public DalAchievementUser ToDal(AchievementUser dbEntity)
        {
            return new DalAchievementUser
            {
                Id = dbEntity.Id,
                UserId = dbEntity.UserId,
                AchievementId = dbEntity.AchievementId
            };

        }

        public AchievementUser ToDataBase(DalAchievementUser dalObj)
        {
            return new AchievementUser
            {
                Id = dalObj.Id,
                UserId = dalObj.UserId,
                AchievementId = dalObj.AchievementId
            };
        }

        public Expression<Func<AchievementUser, bool>> ToDataBaseExpression(Expression<Func<DalAchievementUser, bool>> sourceExpression)
        {
            return visitorMapper.ToDataBaseExpression(sourceExpression);
        }

        public Expression<Func<AchievementUser, object>> ToDataBaseExpressionInclude(Expression<Func<DalAchievementUser, object>> sourceExpression)
        {
            return visitorMapper.ToDataBaseExpressionInclude(sourceExpression);
        }
    }
}
