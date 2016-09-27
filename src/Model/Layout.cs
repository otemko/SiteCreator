using System.Collections.Generic;

namespace SiteCreator.Entities
{
    public class Layout : WithId<int>
    {
        public virtual int Id { get; set; }
        public virtual string Html { get; set; }
        public virtual byte[] Image { get; set; }

        public virtual ICollection<Page> Page { get; set; }
    }
}