using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ORM.Model
{
    public class Tag: IEntity
    {
        public int Id { get; set; }
        public int Name { get; set; }

        public virtual ICollection<TagSite> TagSite { get; set; }
    }
}