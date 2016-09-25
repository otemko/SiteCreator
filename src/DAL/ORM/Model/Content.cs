using System.ComponentModel.DataAnnotations;

namespace DAL.ORM.Model
{
    public class Content: IEntity
    {
        public int Id { get; set; }
        public string Html { get; set; }

        public int PageId { get; set; }
        public virtual Page Page { get; set; }
    }
}