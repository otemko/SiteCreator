using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.ORM.Model
{
    public class StyleMenu : IEntity
    {
        [Required]
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Site> Site { get; set; }
    }
}