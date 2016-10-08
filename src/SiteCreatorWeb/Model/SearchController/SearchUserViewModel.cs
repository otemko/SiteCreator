using SiteCreator.Entities;

namespace SiteCreator.Web.Model.SearchController
{
    public class SearchUserViewModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }

        public SearchUserViewModel(User user)
        {
            Id = user.Id;
            UserName = user.UserName;
        }
    }
}
