using SiteCreator.Entities;

namespace SiteCreator.Web.Model.SearchController
{
    public class SearchPageViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public SearchPageViewModel(Page page)
        {
            Id = page.Id;
            Name = page.Name;
        }
    }
}
