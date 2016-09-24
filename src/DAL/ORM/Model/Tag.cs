using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.ORM.Model
{
    public class Tag: IEntity
    {
        [Required]
        [Key]
        public int Id { get; set; }
        public int Name { get; set; }

        public virtual ICollection<TagSite> TagSite { get; set; }
    }
}