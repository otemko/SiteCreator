using System;
using System.Collections.Generic;

namespace SiteCreator.Entities
{
    public class Page : WithId<int>
    {
        public virtual int Id { get; set; }
        public virtual int Order { get; set; }
        public virtual int Rating { get; set; }
        public virtual DateTime LastModififcation { get; set; }

        public virtual int SiteId { get; set; }
        public virtual Site Site { get; set; }

        public virtual int LayoutId { get; set; }
        public virtual Layout Layout { get; set; }

        public virtual int ContentId { get; set; }
        public virtual Content Content { get; set; }

        public virtual ICollection<Comment> Comment { get; set; }

    }
}