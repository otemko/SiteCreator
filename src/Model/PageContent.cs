using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteCreator.Model
{
    public class PageContent
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int PageId { get; set; }
    }
}
