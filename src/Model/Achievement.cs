using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SiteCreator.Entities
{
    public class Achievement: WithId<int>
    {
        public virtual int Id { get; set; }
        public virtual string Description { get; set; }
        public virtual byte[] Image { get; set; }

        //public virtual ICollection<User> Users { get; set; }
    }
}