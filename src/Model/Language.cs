using System.Collections.Generic;

namespace SiteCreator.Entities
{
    public class Language : WithId<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }

        public virtual ICollection<User> User { get; set; }
    }
}