using SiteCreator.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace SiteCreator.Entities
{
    public class TagSite : WithId<int>
    {
        public int Id { get; set; }

        public int SiteId { get; set; }
        public virtual Site Site { get; set; }

        public int TagId { get; set; }
        public virtual Tag Tag { get; set; }
    }
}
