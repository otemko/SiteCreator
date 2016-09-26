using System;
using System.Linq.Expressions;
using DAL.DTO;
using DAL.Interfaces;
using DAL.Mapper;
using ORM;
using ORM.Model;

namespace DAL.Concrete
{
    public class AchievementRepository : EntityRepository<Achievement, DalAchievement>, 
        IAchievementRepository, IMapper<Achievement, DalAchievement>
    {
        private readonly IVisitor<Achievement, DalAchievement> visitorMapper;

        public AchievementRepository(SiteCreatorDbContext context) : base(context)
        {
            visitorMapper = visitorMapper;

        }

        public DalAchievement ToDal(Achievement dbEntity)
        {
            return new DalAchievement
            {
                Id = dbEntity.Id,
                Description = dbEntity.Description,
                Image = dbEntity.Image        
            };
        }

        public Achievement ToDataBase(DalAchievement dalObj)
        {
            return new Achievement
            {
                Id = dalObj.Id,
                Description = dalObj.Description,
                Image = dalObj.Image
            };
        }

        public Expression<Func<Achievement, bool>> ToDataBaseExpression(Expression<Func<DalAchievement, bool>> sourceExpression)
        {
            return visitorMapper.ToDataBaseExpression(sourceExpression);
        }

        public Expression<Func<Achievement, object>> ToDataBaseExpressionInclude(Expression<Func<DalAchievement, object>> sourceExpression)
        {
            return visitorMapper.ToDataBaseExpressionInclude(sourceExpression);
        }
    }
}
