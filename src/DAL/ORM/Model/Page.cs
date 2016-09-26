using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.ORM.Model
{
    public class Page: IEntity
    {
        public int Id { get; set; }
        public int Order { get; set; }
        public int Rating { get; set; }
        public DateTime LastModififcation { get; set; }

        public int SiteId { get; set; }
        public virtual Site Site { get; set; }

        public int LayoutId { get; set; }
        public virtual Layout Layout { get; set; }

        public int ContentId { get; set; }
        public virtual Content Content { get; set; }

        public virtual ICollection<Comment> Comment { get; set; }

    }
}