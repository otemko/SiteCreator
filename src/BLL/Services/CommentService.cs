using SiteCreator.BLL.IService;
using SiteCreator.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SiteCreator.DAL;

namespace SiteCreator.BLL.Services
{
    public class CommentService : EntityService<Comment, int>, ICommentService
    {
        IEntityRepository repository;

        public CommentService(IEntityRepository repository) : base(repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<Comment>> GetCommentsForPage(int pageId)
        {
            return await repository.GetAllAsync<Comment>(p => p.PageId == pageId, p => p.User);
        }
    }
}
