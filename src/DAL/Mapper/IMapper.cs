using DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DAL.Mapper
{
    public interface IMapper<TEntity, TDal> where TDal : IDalEntity
    {
        TEntity ToDataBase(TDal dalObj);
        TDal ToDal(TEntity dbEntity);
        Expression<Func<TEntity, bool>> ToDataBaseExpression(Expression<Func<TDal, bool>> sourceExpression);
        Expression<Func<TEntity, object>> ToDataBaseExpressionInclude(Expression<Func<TDal, object>> sourceExpression);
    }
}
