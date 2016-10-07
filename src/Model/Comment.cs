namespace SiteCreator.Entities
{
    public class Comment : WithId<int>
    {
        public int Id { get; set; }
        public string Content { get; set; }

        public string UserId { get; set; }
        public virtual User User { get; set; }

        public int PageId { get; set; }
        public virtual Page Page { get; set; }
    }
}