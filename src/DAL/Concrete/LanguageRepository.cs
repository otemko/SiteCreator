using System;
using System.Linq.Expressions;
using DAL.DTO;
using DAL.Interfaces;
using DAL.Mapper;
using ORM;
using ORM.Model;

namespace DAL.Concrete
{
    public class LanguageRepository : EntityRepository<Language, DalLanguage>,
        ILanguageRepository, IMapper<Language, DalLanguage>
    {
        private readonly IVisitor<Language, DalLanguage> visitorMapper;
        public LanguageRepository(SiteCreatorDbContext context) : base(context)
        {
        }

        public DalLanguage ToDal(Language dbEntity)
        {
            return new DalLanguage
            {
                Id = dbEntity.Id,
                Name = dbEntity.Name,
                Url = dbEntity.Url
            };
        }

        public Language ToDataBase(DalLanguage dalObj)
        {
            return new Language
            {
                Id = dalObj.Id,
                Name = dalObj.Name,
                Url = dalObj.Url
            };
        }

        public Expression<Func<Language, bool>> ToDataBaseExpression(Expression<Func<DalLanguage, bool>> sourceExpression)
        {
            return visitorMapper.ToDataBaseExpression(sourceExpression);
        }

        public Expression<Func<Language, object>> ToDataBaseExpressionInclude(Expression<Func<DalLanguage, object>> sourceExpression)
        {
            return visitorMapper.ToDataBaseExpressionInclude(sourceExpression);
        }
    }
}
