using SiteCreator.BLL.IService;
using SiteCreator.DAL;
using SiteCreator.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;

namespace SiteCreator.BLL.Services
{
    public class TagService : EntityService<Tag, int>, ITagService
    {
        IEntityRepository repository;
        IEqualityComparer<Tag> comparer;

        public TagService(IEntityRepository repository) : base(repository)
        {
            this.repository = repository;
            comparer = new TagEqualityConmarer();
        }

        public async Task<IEnumerable<Tag>> CreateTags(List<Tag> tags)
        {
            var validTags = tags.Where(p => !string.IsNullOrWhiteSpace(p.Name)).Distinct(comparer).ToList();
            var repositoryTags = await GetRepositoryTags(validTags);
            FillVRepositoryTagsIntoValidTags(validTags, repositoryTags);
            await SaveNewTagsToDb(validTags, repositoryTags);

            return validTags;
        }

        void FillVRepositoryTagsIntoValidTags(List<Tag> validTags, List<Tag> repositoryTags)
        {
            foreach (var tag in repositoryTags)
            {
                var index = validTags.FindIndex(p => comparer.Equals(tag, p));
                validTags[index] = tag;
            }
        }

        async Task SaveNewTagsToDb(List<Tag> validTags, List<Tag> repositoryTags)
        {
            var newTags = validTags.Except(repositoryTags, comparer);
            await repository.CreateRangeAsync(newTags.ToArray());
        }

        async Task<List<Tag>> GetRepositoryTags(List<Tag> validTags)
        {
            var repositoryTags = await repository.GetAllAsync<Tag>(p => validTags.Contains(p, comparer));
            return repositoryTags.Distinct(comparer).ToList();
        }

        public async Task<IEnumerable<Tag>> GetAllNonRepeatTagsAsync()
        {
            var tags = await repository.GetAllAsync<Tag>();
            return tags.Distinct(comparer).ToList();
        }
    }

    public class TagEqualityConmarer : IEqualityComparer<Tag>
    {
        public bool Equals(Tag x, Tag y)
        {
            return (x.Name.Equals(y.Name, StringComparison.OrdinalIgnoreCase));
        }

        public int GetHashCode(Tag obj)
        {
            return obj.Name.ToUpper().GetHashCode();
        }
    }
}
