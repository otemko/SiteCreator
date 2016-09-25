using System.ComponentModel.DataAnnotations;

namespace DAL.ORM.Model
{
    public class AchievementUser: IEntity
    {
        public int Id { get; set; }

        public string UserId { get; set; }
        public virtual User User { get; set; }

        public int AchievementId { get; set; }
        public virtual Achievement Achievement { get; set; }
    }
}