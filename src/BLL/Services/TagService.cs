using SiteCreator.BLL.IService;
using SiteCreator.DAL;
using SiteCreator.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteCreator.BLL.Services
{
    public class TagService : EntityService<Tag, int>, ITagService
    {
        IEntityRepository repository;

        public TagService(IEntityRepository repository): base(repository)
        {
            this.repository = repository;
        }

        public async Task CreateTags(List<Tag> tags)
        {
            var repoTags = await repository.GetAllAsync<Tag>(p => tags.Select(q => q.Name).Contains(p.Name));
            foreach (var repoTag in repoTags)
            {
                int i = tags.FindIndex(p => p.Name == repoTag.Name);
                if (i > -1) tags[i] = repoTag;
            }

            var newTags = tags.Except(repoTags);
            await repository.CreateRangeAsync(newTags.ToArray());
        }

    }
}
