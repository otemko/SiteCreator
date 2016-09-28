using SiteCreator.Entities;
using System;
using System.Collections.Generic;


namespace SiteCreator.Web.Model.SiteController
{
    public class SiteViewModel
    {
        public virtual int Id { get; set; }
        public virtual DateTime DateCreated { get; set; }
        public virtual string Name { get; set; }
        public UserViewModelSite User { get; set; }
        public virtual IEnumerable<TagViewModelSite> Tags { get; set; }

        public SiteViewModel(Site site, IEnumerable<Tag> tags)
        {
            Id = site.Id;
            DateCreated = site.DateCreated;
            Name = site.Name;

            User = new UserViewModelSite
            {
                Id = site.UserId,
                FirstName = site.User.FirstName,
                LastName = site.User.LastName
            };
            
            var listTags = new List<TagViewModelSite>();

            foreach (var tag in tags)
            {
                listTags.Add(new TagViewModelSite
                {
                    Id = tag.Id,
                    Name = tag.Name
                });
            }

            Tags = listTags;
        }
    }
}
