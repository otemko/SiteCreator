namespace SiteCreator.Entities
{
    public class AchievementUser: WithId<int>
    {
        public virtual int Id { get; set; }

        public virtual string UserId { get; set; }
        public virtual User User { get; set; }

        public virtual int AchievementId { get; set; }
        public virtual Achievement Achievement { get; set; }
    }
}