using DAL.Interfaces;
using ORM;
using DAL.Mapper;
using ORM.Model;
using DAL.DTO;
using System;
using System.Linq.Expressions;

namespace DAL.Concrete
{
    public class LayoutRepository : EntityRepository<Layout, DalLayout>,
        ILayoutRepository, IMapper<Layout, DalLayout>
    {
        private readonly IVisitor<Layout, DalLayout> visitorMapper;
        public LayoutRepository(SiteCreatorDbContext context) : base(context)
        {
        }

        public DalLayout ToDal(Layout dbEntity)
        {
            return new DalLayout
            {
                Id = dbEntity.Id,
                Html = dbEntity.Html,
                Image = dbEntity.Image
            };
        }

        public Layout ToDataBase(DalLayout dalObj)
        {
            return new Layout
            {
                Id = dalObj.Id,
                Html = dalObj.Html,
                Image = dalObj.Image
            };
        }

        public Expression<Func<Layout, bool>> ToDataBaseExpression(Expression<Func<DalLayout, bool>> sourceExpression)
        {
            return visitorMapper.ToDataBaseExpression(sourceExpression);
        }

        public Expression<Func<Layout, object>> ToDataBaseExpressionInclude(Expression<Func<DalLayout, object>> sourceExpression)
        {
            return visitorMapper.ToDataBaseExpressionInclude(sourceExpression);
        }
    }
}
