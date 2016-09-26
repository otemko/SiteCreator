using System;
using System.Linq.Expressions;
using DAL.DTO;
using DAL.Interfaces;
using DAL.Mapper;
using ORM.Model;
using ORM;

namespace DAL.Concrete
{
    public class PageRepository : EntityRepository<Page, DalPage>,
        IPageRepository, IMapper<Page, DalPage>
    {
        private readonly IVisitor<Page, DalPage> visitorMapper;
        public PageRepository(SiteCreatorDbContext context) : base(context)
        {
    }

        public DalPage ToDal(Page dbEntity)
        {
            return new DalPage
            {
                Id = dbEntity.Id,
                ContentId = dbEntity.ContentId,
                LastModififcation = dbEntity.LastModififcation,
                LayoutId = dbEntity.LayoutId,
                Order = dbEntity.Order,
                Rating = dbEntity.Rating,
                SiteId= dbEntity.SiteId
            };
        }

        public Page ToDataBase(DalPage dalObj)
        {
            return new Page
            {
                Id = dalObj.Id,
                ContentId = dalObj.ContentId,
                LastModififcation = dalObj.LastModififcation,
                LayoutId = dalObj.LayoutId,
                Order = dalObj.Order,
                Rating = dalObj.Rating,
                SiteId = dalObj.SiteId
            };
        }

        public Expression<Func<Page, bool>> ToDataBaseExpression(Expression<Func<DalPage, bool>> sourceExpression)
        {
            return visitorMapper.ToDataBaseExpression(sourceExpression);
        }

        public Expression<Func<Page, object>> ToDataBaseExpressionInclude(Expression<Func<DalPage, object>> sourceExpression)
        {
            return visitorMapper.ToDataBaseExpressionInclude(sourceExpression);
        }
    }
}
