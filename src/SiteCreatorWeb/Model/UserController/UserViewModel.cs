
using SiteCreator.Entities;

namespace SiteCreator.Web.Model.UserController
{
    public class UserViewModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }
        public bool IsLockoutEnabled { get; set; }
        public UserViewModel()
        {

        }

        public UserViewModel(User user, string role)
        {
            Id = user.Id;
            UserName = user.UserName;
            Role = role;
            IsLockoutEnabled = user.LockoutEnabled;
        }
    }
}
