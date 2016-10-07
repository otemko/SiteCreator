using SiteCreator.Model;
using System;
using System.Collections.Generic;

namespace SiteCreator.Entities
{
    public class Page : WithId<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Preview { get; set; }
        public int Order { get; set; }
        public decimal Rating { get; set; }
        public int CountRated { get; set; }
        public DateTime LastModififcation { get; set; }
        public int SiteId { get; set; }
        public virtual Site Site { get; set; }
        public int PageContentId { get; set; }
        public virtual PageContent PageContent { get; set; }
        public bool CommentsEnabled { get; set; }
        public virtual ICollection<Comment> Comment { get; set; }

    }
}