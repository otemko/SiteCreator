using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ORM.Model
{
    public class User: IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int StyleId { get; set; }
        public virtual Style Style { get; set; }

        public int LanguageId { get; set; }
        public virtual Language Language { get; set; }

        public virtual ICollection<Comment> Comment { get; set; }

        public virtual ICollection<AchievementUser> AchievementUser { get; set; }

        public virtual ICollection<Site> Site { get; set; }               
    }
}