using System;
using DAL.Interfaces;
using DAL.Mapper;
using ORM;
using ORM.Model;
using DAL.DTO;

namespace DAL.Concrete
{
    public class TagSiteRepository : EntityRepository<TagSite, DalTagSite>,
        ITagSiteRepository, IMapper<TagSite, DalTagSite>
    {
        private readonly IVisitor<TagSite, DalTagSite> visitorMapper;
        public TagSiteRepository(SiteCreatorDbContext context) : base(context)
        {
        }

        public DalTagSite ToDal(TagSite dbEntity)
        {
            return new DalTagSite
            {
                Id = dbEntity.Id,
                SiteId = dbEntity.SiteId,
                TagId = dbEntity.TagId
            };
        }

        public TagSite ToDataBase(DalTagSite dalObj)
        {
            return new TagSite
            {
                Id = dalObj.Id,
                SiteId = dalObj.SiteId,
                TagId = dalObj.TagId
            };
        }

        public System.Linq.Expressions.Expression<Func<TagSite, bool>> ToDataBaseExpression(System.Linq.Expressions.Expression<Func<DalTagSite, bool>> sourceExpression)
        {
            return visitorMapper.ToDataBaseExpression(sourceExpression);
        }

        public System.Linq.Expressions.Expression<Func<TagSite, object>> ToDataBaseExpressionInclude(System.Linq.Expressions.Expression<Func<DalTagSite, object>> sourceExpression)
        {
            return visitorMapper.ToDataBaseExpressionInclude(sourceExpression);
        }
    }
}
