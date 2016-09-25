using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace DAL.ORM.Model
{
    public class Layout: IEntity
    {
        public int Id { get; set; }
        public string Html { get; set; }
        public byte[] Image { get; set; }

        public virtual ICollection<Page> Page { get; set; }
    }
}