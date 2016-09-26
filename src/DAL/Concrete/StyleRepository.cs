using System;
using DAL.Interfaces;
using DAL.Mapper;
using ORM.Model;
using DAL.DTO;
using ORM;

namespace DAL.Concrete
{
    public class StyleRepository : EntityRepository<Style, DalStyle>,
        IStyleRepository, IMapper<Style, DalStyle>
    {
        private readonly IVisitor<Style, DalStyle> visitorMapper;
        public StyleRepository(SiteCreatorDbContext context) : base(context)
        {
        }

        public DalStyle ToDal(Style dbEntity)
        {
            return new DalStyle
            {
                Id = dbEntity.Id,
                Name = dbEntity.Name,
                Url = dbEntity.Url
            };
        }

        public Style ToDataBase(DalStyle dalObj)
        {
            return new Style
            {
                Id = dalObj.Id,
                Name = dalObj.Name,
                Url = dalObj.Url
            };
        }

        public System.Linq.Expressions.Expression<Func<Style, bool>> ToDataBaseExpression(System.Linq.Expressions.Expression<Func<DalStyle, bool>> sourceExpression)
        {
            return visitorMapper.ToDataBaseExpression(sourceExpression);
        }

        public System.Linq.Expressions.Expression<Func<Style, object>> ToDataBaseExpressionInclude(System.Linq.Expressions.Expression<Func<DalStyle, object>> sourceExpression)
        {
            return visitorMapper.ToDataBaseExpressionInclude(sourceExpression);
        }
    }
}
