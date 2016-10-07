using SiteCreator.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteCreator.Web.Model
{
    public class UserInfoViewModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public int LanguageId { get; set; }
        public int StyleId { get; set; }
        public string Role { get; set; }
        public bool IsLockoutEnabled { get; set; }

        public UserInfoViewModel(User user, string role)
        {
            Id = user.Id;
            UserName = user.UserName;
            LanguageId = user.LanguageId;
            StyleId = user.StyleId;
            Role = role;
            IsLockoutEnabled = user.LockoutEnabled;
        }
    }
}
