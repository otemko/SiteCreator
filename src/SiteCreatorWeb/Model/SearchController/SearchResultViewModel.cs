using System.Collections.Generic;

namespace SiteCreator.Web.Model.SearchController
{
    public class SearchResultViewModel
    {
        public ICollection<SearchSiteViewModel> SearchSites { get; set; }
        public ICollection<SearchPageViewModel> SearchPages { get; set; }
        public ICollection<SearchUserViewModel> SearchUsers { get; set; }
    }
}
