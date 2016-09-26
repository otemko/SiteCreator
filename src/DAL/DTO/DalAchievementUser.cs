
namespace DAL.DTO
{
    public class DalAchievementUser : IDalEntity
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public int AchievementId { get; set; }
    }
}
