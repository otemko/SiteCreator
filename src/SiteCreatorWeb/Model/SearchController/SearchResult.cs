using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteCreator.Web.Model.SearchController
{
    public class SearchResult
    {
        public ICollection<SearchSite> SearchSites { get; set; }
        public ICollection<SearchTag> SearchTags { get; set; }
        public ICollection<SearchUser> SearchUsers { get; set; }
    }
}
