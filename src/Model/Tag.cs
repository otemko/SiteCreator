using System;
using System.Collections.Generic;

namespace SiteCreator.Entities
{
    public class Tag : WithId<int>
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }

        public virtual ICollection<TagSite> TagSite { get; set; }

       
    }
}