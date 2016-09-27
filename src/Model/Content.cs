namespace SiteCreator.Entities
{
    public class Content : WithId<int>
    {
        public virtual int Id { get; set; }
        public virtual string Html { get; set; }

        public virtual int PageId { get; set; }
        public virtual Page Page { get; set; }
    }
}