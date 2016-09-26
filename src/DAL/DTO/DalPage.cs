using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.DTO
{
    public class DalPage : IDalEntity
    {
        public int Id { get; set; }
        public int Order { get; set; }
        public int Rating { get; set; }
        public DateTime LastModififcation { get; set; }

        public int SiteId { get; set; }

        public int LayoutId { get; set; }

        public int ContentId { get; set; }
        
    }
}
