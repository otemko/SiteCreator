using System.Collections.Generic;

namespace SiteCreator.Entities
{
    public class StyleMenu : WithId<int>
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }

        public virtual ICollection<Site> Site { get; set; }
    }
}