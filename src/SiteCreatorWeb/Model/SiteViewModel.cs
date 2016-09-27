using SiteCreator.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteCreator.Web.Model
{
    public class SiteViewModel
    {
        public virtual int Id { get; set; }
        public virtual DateTime DateCreated { get; set; }
        public virtual string Name { get; set; }
        public UserViewModelSite User { get; set; }
        public virtual string[] TagSite { get; set; }

        public SiteViewModel(Site site)
        {
            Id = site.Id;
            DateCreated = site.DateCreated;
            Name = site.Name;

            User.Id = site.User.Id;
            User.FirstName = site.User.FirstName;
            User.FirstName = site.User.LastName;                     

            //TagSite = site.TagSite.
        }
    }
}
