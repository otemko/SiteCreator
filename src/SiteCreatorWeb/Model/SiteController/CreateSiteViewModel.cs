using SiteCreator.Entities;
using SiteCreator.Web.Model.Shared;
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
        public string preview { get; set; }
        public string name { get; set; }
        public string userId { get; set; }
        public int styleMenuId { get; set; }
        public Page[] pages { get; set; }
        public TagViewModel[] tags { get; set; }


        public Site createBllSite()
        {
            return new Site
            {
                Name = name,
                DateCreated = DateTime.Now,
                Preview = preview,
                StyleMenuId = styleMenuId,
                UserId = userId
            };
        }

        internal void UpdateBllSite(Site site)
        {
            site.Name = name;
            site.Preview = preview;
            site.StyleMenuId = styleMenuId;

            foreach (var page in pages)
            {
                var p = site.Page.FirstOrDefault(q => q.Id == page.Id);
                if (p != null) p.Order = page.Order;
            }
        }
    }
}
