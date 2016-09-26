using DAL.DTO;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace DAL.Mapper
{
    public class Visitor<TEntity, TDal> : ExpressionVisitor, IVisitor<TEntity, TDal>
        where TDal : IDalEntity
    {
        private readonly Dictionary<MemberInfo, MemberInfo> mapDictionary;
        private readonly ParameterExpression parameterExpression;

        public Visitor()
        {
            mapDictionary = new Dictionary<MemberInfo, MemberInfo>();
            parameterExpression = Expression.Parameter(typeof(TEntity));
        }

        public Expression<Func<TEntity, bool>> ToDataBaseExpression(
            Expression<Func<TDal, bool>> sourceExpression)
        {
            if (sourceExpression == null) throw new ArgumentNullException(nameof(sourceExpression));

            return Expression.Lambda<Func<TEntity, bool>>(Visit(sourceExpression.Body), parameterExpression);
        }

        public Expression<Func<TEntity, object>> ToDataBaseExpressionInclude(
            Expression<Func<TDal, object>> sourceExpression)
        {
            if (sourceExpression == null) throw new ArgumentNullException(nameof(sourceExpression));

            return Expression.Lambda<Func<TEntity, object>>(Visit(sourceExpression.Body), parameterExpression);
        }

        public IVisitor<TEntity, TDal> Map<TProperty>(Expression<Func<TDal, TProperty>> targetProperty,
            Expression<Func<TEntity, TProperty>> sourceProperty)
        {
            if (sourceProperty == null) throw new ArgumentNullException(nameof(sourceProperty));

            mapDictionary.Add(GetPropertyInfo(targetProperty), GetPropertyInfo(sourceProperty));

            return this;
        }

        protected override Expression VisitMember(MemberExpression node)
        {
            if (IsParameterProperty(node))
            {
                return Expression.MakeMemberAccess(parameterExpression, mapDictionary[node.Member]);
            }

            return node;
        }

        private bool IsParameterProperty(MemberExpression node)
        {
            if (node.Expression == null)
                return false;

            if (node.Expression.NodeType == ExpressionType.Parameter)
                return true;

            if (node.Expression.NodeType != ExpressionType.MemberAccess)
                return false;

            return IsParameterProperty((MemberExpression)node.Expression);
        }

        private PropertyInfo GetPropertyInfo<TSource, TValue>(
            Expression<Func<TSource, TValue>> expression)
        {
            return (PropertyInfo)((MemberExpression)expression.Body).Member;
        }
    }
}
