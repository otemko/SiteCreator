using SiteCreator.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SiteCreator.BLL.IService
{
    public interface ITagService : IEntityService<Tag, int>
    {
        Task<IEnumerable<Tag>> CreateTags(List<Tag> tags);
        Task<IEnumerable<Tag>> GetAllNonRepeatTagsAsync();
    }
}
