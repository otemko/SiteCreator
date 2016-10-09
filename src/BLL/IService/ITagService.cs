using SiteCreator.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SiteCreator.BLL.IService
{
    public interface ITagService : IEntityService<Tag, int>
    {
        Task CreateTags(List<Tag> tags);
    }
}
