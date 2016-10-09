using SiteCreator.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteCreator.Web.Model.TagSiteController
{
    public class TagSiteViewModel
    {
        public int TagId { get; set; }
        public string TagName { get; set; }

        public TagSiteViewModel(TagSite tagSite)
        {
            TagId = tagSite.TagId;
            TagName = tagSite.Tag.Name;
        }
    }
}
