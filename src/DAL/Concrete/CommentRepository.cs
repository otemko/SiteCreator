using DAL.Interfaces;
using ORM.Model;
using DAL.DTO;
using DAL.Mapper;
using ORM;
using System;
using System.Linq.Expressions;

namespace DAL.Concrete
{
    public class CommentRepository : EntityRepository<Comment, DalComment>,
        ICommentUserRepository, IMapper<Comment, DalComment>
    {
        private readonly IVisitor<Comment, DalComment> visitorMapper;
        public CommentRepository(SiteCreatorDbContext context) : base(context)
        {
        }

        public DalComment ToDal(Comment dbEntity)
        {
            return new DalComment
            {
                Id = dbEntity.Id,
                Content = dbEntity.Content,
                PageId = dbEntity.PageId,
                UserId = dbEntity.UserId
            };
        }

        public Comment ToDataBase(DalComment dalObj)
        {
            return new Comment
            {
                Id = dalObj.Id,
                Content = dalObj.Content,
                PageId = dalObj.PageId,
                UserId = dalObj.UserId
            };
        }

        public Expression<Func<Comment, bool>> ToDataBaseExpression(Expression<Func<DalComment, bool>> sourceExpression)
        {
            return visitorMapper.ToDataBaseExpression(sourceExpression);
        }

        public Expression<Func<Comment, object>> ToDataBaseExpressionInclude(Expression<Func<DalComment, object>> sourceExpression)
        {
            return visitorMapper.ToDataBaseExpressionInclude(sourceExpression);
        }
    }
}
