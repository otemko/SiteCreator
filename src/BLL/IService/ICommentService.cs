using SiteCreator.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteCreator.BLL.IService
{
    public interface ICommentService : IEntityService<Comment, int>
    {
        Task<IEnumerable<Comment>> GetCommentsForPage(int pageId);
    }
}
