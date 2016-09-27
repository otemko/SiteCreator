using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Collections.Generic;

namespace SiteCreator.Entities
{
    public class User : IdentityUser, WithId<string>
    {
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }

        public virtual int StyleId { get; set; }
        public virtual Style Style { get; set; }

        public virtual int LanguageId { get; set; }
        public virtual Language Language { get; set; }

        public virtual ICollection<Comment> Comment { get; set; }

        public virtual ICollection<AchievementUser> AchievementUser { get; set; }

        public virtual ICollection<Site> Site { get; set; }               
    }
}