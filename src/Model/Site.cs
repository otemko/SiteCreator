using System;
using System.Collections.Generic;

namespace SiteCreator.Entities
{
    public class Site : WithId<int>
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public string Name { get; set; }
        public string Preview { get; set; }
        public string UserId { get; set; }
        public virtual User User { get; set; }

        public int StyleMenuId { get; set; }
        public virtual StyleMenu StyleMenu { get; set; }

        public virtual ICollection<Page> Page { get; set; }

        public virtual ICollection<TagSite> TagSite { get; set; }
    }
}