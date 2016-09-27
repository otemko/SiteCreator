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
        public string UserId { get; set; }
        public virtual string[] TagSite { get; set; }

        public SiteViewModel(Site site)
        {
            Id = site.Id;
            DateCreated = site.DateCreated;
            Name = site.Name;
            UserId = site.User.Id;
        }
    }
}
