using SiteCreator.Entities;
using SiteCreator.Web.Model.Shared;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SiteCreator.Web.Model.SiteController
{
    public class SiteViewModel
    {
        public virtual int Id { get; set; }
        public virtual DateTime DateCreated { get; set; }
        public virtual string Name { get; set; }
        public string UserName { get; set; }
        public string UserId { get; set; }
        public virtual int StyleMenuId { get; set; }
        public virtual List<TagViewModel> Tags { get; set; }

        public SiteViewModel(Site site, IEnumerable<Tag> tags)
        {
            Id = site.Id;
            DateCreated = site.DateCreated;
            Name = site.Name;

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
            Id = site.Id;
            DateCreated = site.DateCreated;
            Name = site.Name;

            UserName = site.User.UserName;
            UserId = site.UserId;

            StyleMenuId = site.StyleMenuId;

            Tags = new List<TagViewModel>();
            site.TagSite.ToList().ForEach(p => Tags.Add(new TagViewModel(p.Tag)));
        }
    }
}
