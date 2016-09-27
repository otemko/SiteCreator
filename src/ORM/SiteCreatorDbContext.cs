using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SiteCreator.Entities;

namespace SiteCreator.ORM
{
    public class SiteCreatorDbContext : IdentityDbContext<User>
    {
        public DbSet<Achievement> Achievement { get; set; }
        public DbSet<AchievementUser> AchievementUser { get; set; }
        public DbSet<Comment> Comment { get; set; }
        public DbSet<Content> Content { get; set; }
        public DbSet<Language> Language { get; set; }
        public DbSet<Layout> Layout { get; set; }
        public DbSet<Page> Page { get; set; }
        public DbSet<Site> Site { get; set; }
        public DbSet<Style> Style { get; set; }
        public DbSet<StyleMenu> StyleMenu { get; set; }
        public DbSet<Tag> Tag { get; set; }
        public DbSet<TagSite> TagSite { get; set; }

        public SiteCreatorDbContext(DbContextOptions<SiteCreatorDbContext> options)
            : base(options)
        {
            
        }
        
    }
}