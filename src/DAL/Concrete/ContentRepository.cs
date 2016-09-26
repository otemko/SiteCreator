using System;
using System.Linq.Expressions;
using DAL.DTO;
using DAL.Interfaces;
using DAL.Mapper;
using ORM.Model;
using ORM;

namespace DAL.Concrete
{
    public class ContentRepository : EntityRepository<Content, DalContent>,
        IContentRepository, IMapper<Content, DalContent>
    {
        private readonly IVisitor<Content, DalContent> visitorMapper;
        public ContentRepository(SiteCreatorDbContext context) : base(context)
        {
        }

        public DalContent ToDal(Content dbEntity)
        {
            return new DalContent
            {
                Id = dbEntity.Id,
                Html = dbEntity.Html,
                PageId = dbEntity.PageId
            };
        }

        public Content ToDataBase(DalContent dalObj)
        {
            return new Content
            {
                Id = dalObj.Id,
                Html = dalObj.Html,
                PageId = dalObj.PageId
            };
        }

        public Expression<Func<Content, bool>> ToDataBaseExpression(Expression<Func<DalContent, bool>> sourceExpression)
        {
            return visitorMapper.ToDataBaseExpression(sourceExpression);
        }

        public Expression<Func<Content, object>> ToDataBaseExpressionInclude(Expression<Func<DalContent, object>> sourceExpression)
        {
            return visitorMapper.ToDataBaseExpressionInclude(sourceExpression);
        }
    }
}
