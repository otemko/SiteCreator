using DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IVisitor<TEntity, TDal> where TDal : IDalEntity
    {
        IVisitor<TEntity, TDal> Map<TProperty>(
            Expression<Func<TDal, TProperty>> targetProperty,
            Expression<Func<TEntity, TProperty>> sourceProperty);

        Expression<Func<TEntity, bool>> ToDataBaseExpression(
            Expression<Func<TDal, bool>> sourceExpression);

        Expression<Func<TEntity, object>> ToDataBaseExpressionInclude(
            Expression<Func<TDal, object>> sourceExpression);
    }
}
