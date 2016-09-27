namespace SiteCreator.Entities
{
    public class Comment : WithId<int>
    {
        public virtual int Id { get; set; }
        public virtual string Content { get; set; }

        public virtual string UserId { get; set; }
        public virtual User User { get; set; }

        public virtual int PageId { get; set; }
        public virtual Page Page { get; set; }
    }
}