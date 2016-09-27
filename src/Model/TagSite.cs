namespace SiteCreator.Entities
{
    public class TagSite : WithId<int>
    {
        public virtual int Id { get; set; }

        public virtual int SiteId { get; set; }
        public virtual Site Site { get; set; }

        public virtual int TagId { get; set; }
        public virtual Tag Tag { get; set; }
    }
}