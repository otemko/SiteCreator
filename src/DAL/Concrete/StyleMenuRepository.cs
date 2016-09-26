using System;
using System.Linq.Expressions;
using DAL.Interfaces;
using DAL.Mapper;
using ORM;
using ORM.Model;
using DAL.DTO;

namespace DAL.Concrete
{
    public class StyleMenuRepository : EntityRepository<StyleMenu, DalStyleMenu>,
        IStyleMenuRepository, IMapper<StyleMenu, DalStyleMenu>
    {
        private readonly IVisitor<StyleMenu, DalStyleMenu> visitorMapper;
        public StyleMenuRepository(SiteCreatorDbContext context) : base(context)
        {
        }

        public DalStyleMenu ToDal(StyleMenu dbEntity)
        {
            return new DalStyleMenu
            {
                Id = dbEntity.Id,
                Name = dbEntity.Name
            };
        }

        public StyleMenu ToDataBase(DalStyleMenu dalObj)
        {
            return new StyleMenu
            {
                Id = dalObj.Id,
                Name = dalObj.Name
            };
        }

        public Expression<Func<StyleMenu, bool>> ToDataBaseExpression(Expression<Func<DalStyleMenu, bool>> sourceExpression)
        {
            return visitorMapper.ToDataBaseExpression(sourceExpression);
        }

        public Expression<Func<StyleMenu, object>> ToDataBaseExpressionInclude(Expression<Func<DalStyleMenu, object>> sourceExpression)
        {
            return visitorMapper.ToDataBaseExpressionInclude(sourceExpression);
        }
    }
}
