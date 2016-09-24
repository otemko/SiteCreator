using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.ORM.Model
{
    public class Achievement: IEntity
    {
        [Required]
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }

        public virtual ICollection<AchievementUser> AchievementUser { get; set; }
    }
}