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
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int LanguageId { get; set; }
        public int StyleId { get; set; }

        public UserInfoViewModel(User user)
        {
            Id = user.Id;
            UserName = user.UserName;
            FirstName = user.FirstName;
            LastName = user.LastName;
            LanguageId = user.LanguageId;
            StyleId = user.StyleId;
        }
    }
}
