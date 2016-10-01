using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteCreator.Web.Model.SiteController
{
    public class CreateSiteViewModel
    {
        public int id { get; set; }
        public string dateCreated { get; set; }
        public string name { get; set; }
        public string userId { get; set; }
        public int styleMenuId { get; set; }
        public string[] newTags { get; set; }
        public TagsCreateSiteViewModel[] oldTags { get; set; }
    }
}
