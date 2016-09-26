using System;
using System.Linq.Expressions;
using DAL.DTO;
using DAL.Interfaces;
using DAL.Mapper;
using ORM.Model;
using ORM;

namespace DAL.Concrete
{
    public class SiteRepository : EntityRepository<Site, DalSite>,
        ISiteRepository, IMapper<Site, DalSite>
    {
        private readonly IVisitor<Site, DalSite> visitorMapper;
        public SiteRepository(SiteCreatorDbContext context) : base(context)
        {
        }

        public DalSite ToDal(Site dbEntity)
        {
            return new DalSite
            {
                Id = dbEntity.Id,
                DateCreated = dbEntity.DateCreated,
                Name = dbEntity.Name,
                StyleMenuId = dbEntity.StyleMenuId,
                UserId = dbEntity.UserId
            };
        }

        public Site ToDataBase(DalSite dalObj)
        {
            return new Site
            {
                Id = dalObj.Id,
                DateCreated = dalObj.DateCreated,
                Name = dalObj.Name,
                StyleMenuId = dalObj.StyleMenuId,
                UserId = dalObj.UserId
            };
        }

        public Expression<Func<Site, bool>> ToDataBaseExpression(Expression<Func<DalSite, bool>> sourceExpression)
        {
            return visitorMapper.ToDataBaseExpression(sourceExpression);
        }

        public Expression<Func<Site, object>> ToDataBaseExpressionInclude(Expression<Func<DalSite, object>> sourceExpression)
        {
            return visitorMapper.ToDataBaseExpressionInclude(sourceExpression);
        }
    }
}
