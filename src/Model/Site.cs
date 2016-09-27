using System;
using System.Collections.Generic;

namespace SiteCreator.Entities
{
    public class Site : WithId<int>
    {
        public virtual int Id { get; set; }
        public virtual DateTime DateCreated { get; set; }
        public virtual string Name { get; set; }

        public virtual string UserId { get; set; }
        public User User { get; set; }

        public virtual int StyleMenuId { get; set; }
        public virtual StyleMenu StyleMenu { get; set; }

        public virtual ICollection<Page> Page { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }
    }
}