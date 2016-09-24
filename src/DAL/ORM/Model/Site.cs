using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.ORM.Model
{
    public class Site: IEntity
    {
        [Required]
        [Key]
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public string Name { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }

        public int StyleMenuId { get; set; }
        public virtual StyleMenu StyleMenu { get; set; }

        public virtual ICollection<Page> Page { get; set; }

        public virtual ICollection<TagSite> TagSite { get; set; }
    }
}