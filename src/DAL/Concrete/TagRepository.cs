using System;
using DAL.Interfaces;
using DAL.Mapper;
using ORM;
using ORM.Model;
using DAL.DTO;

namespace DAL.Concrete
{
    public class TagRepository : EntityRepository<Tag, DalTag>,
        ITagRepository, IMapper<Tag, DalTag>
    {
        private readonly IVisitor<Tag, DalTag> visitorMapper;
        public TagRepository(SiteCreatorDbContext context) : base(context)
        {
        }

        public DalTag ToDal(Tag dbEntity)
        {
            return new DalTag
            {
                Id = dbEntity.Id,
                Name = dbEntity.Name
            };
        }

        public Tag ToDataBase(DalTag dalObj)
        {
            return new Tag
            {
                Id = dalObj.Id,
                Name = dalObj.Name
            };
        }

        public System.Linq.Expressions.Expression<Func<Tag, bool>> ToDataBaseExpression(System.Linq.Expressions.Expression<Func<DalTag, bool>> sourceExpression)
        {
            return visitorMapper.ToDataBaseExpression(sourceExpression);
        }

        public System.Linq.Expressions.Expression<Func<Tag, object>> ToDataBaseExpressionInclude(System.Linq.Expressions.Expression<Func<DalTag, object>> sourceExpression)
        {
            return visitorMapper.ToDataBaseExpressionInclude(sourceExpression);
        }
    }
}
