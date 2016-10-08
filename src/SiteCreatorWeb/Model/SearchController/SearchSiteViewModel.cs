using SiteCreator.Entities;


namespace SiteCreator.Web.Model.SearchController
{
    public class SearchSiteViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public SearchSiteViewModel(Site site)
        {
            Id = site.Id;
            Name = site.Name;
        }
    }
}
