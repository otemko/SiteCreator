using System.ComponentModel.DataAnnotations;

namespace ORM.Model
{
    public class TagSite: IEntity
    {
        public int Id { get; set; }

        public int SiteId { get; set; }
        public virtual Site Site { get; set; }

        public int TagId { get; set; }
        public virtual Tag Tag { get; set; }
    }
}