using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.ORM.Model
{
    public class Language : IEntity
    {
        [Required]
        [Key]
        public int Id { get; set; }
        public string Url { get; set; }

        public virtual ICollection<User> User { get; set; }
    }
}