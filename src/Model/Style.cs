using System.Collections.Generic;

namespace SiteCreator.Entities
{
    public class Style : WithId<int>
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Url { get; set; }


        public virtual ICollection<User> User { get; set; }
    }
}