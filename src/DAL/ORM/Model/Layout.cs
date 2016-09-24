using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace DAL.ORM.Model
{
    public class Layout: IEntity
    {
        [Required]
        [Key]
        public int Id { get; set; }
        public string Html { get; set; }
        public byte[] Image { get; set; }

        public virtual ICollection<Page> Page { get; set; }
    }
}