using SiteCreator.Entities;
using SiteCreator.Web.Model.PageController;
using SiteCreator.Web.Model.Shared;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SiteCreator.Web.Model.SiteController
{
    public class SiteViewModel
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public string Name { get; set; }
        public string Preview { get; set; }
        public string UserName { get; set; }
        public string UserId { get; set; }
        public int StyleMenuId { get; set; }
        public virtual List<TagViewModel> Tags { get; set; }
        public virtual List<PageInfoViewModel> Pages { get; set; }

        public SiteViewModel(Site site, IEnumerable<Tag> tags)
        {
            Id = site.Id;
            DateCreated = site.DateCreated;
            Name = site.Name;
            Preview = site.Preview;

            UserName = site.User.UserName;
            UserId = site.UserId;

            StyleMenuId = site.StyleMenuId;

            var listTags = new List<TagViewModel>();

            foreach (var tag in tags)
            {
                listTags.Add(new TagViewModel
                {
                    Id = tag.Id,
                    Name = tag.Name
                });
            }

            Tags = listTags;
        }

        public SiteViewModel(Site site)
        {
            if (site == null) return;

            Id = site.Id;
            DateCreated = site.DateCreated;
            Name = site.Name;
            Preview = site.Preview;

            UserName = site.User.UserName;
            UserId = site.UserId;

            StyleMenuId = site.StyleMenuId;

            Tags = new List<TagViewModel>();
            site.TagSite?.ToList().ForEach(p => Tags.Add(new Shared.TagViewModel(p.Tag)));

            Pages = new List<PageInfoViewModel>();
            site.Page?.ToList().ForEach(p => Pages.Add(new PageInfoViewModel(p)));
        }
    }
}
