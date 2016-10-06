using SiteCreator.Model;
using System;
using System.Collections.Generic;

namespace SiteCreator.Entities
{
    public class Page : WithId<int>
    {
        public virtual int Id { get; set; }
        public string Name { get; set; }
        public string Preview { get; set; }
        public virtual int Order { get; set; }
        public decimal Rating { get; set; }
        public int CountRated { get; set; }
        public virtual DateTime LastModififcation { get; set; }

        public virtual int SiteId { get; set; }
        public virtual Site Site { get; set; }

        public int PageContentId { get; set; }
        public PageContent PageContent { get; set; }
        public virtual ICollection<Comment> Comment { get; set; }

    }
}