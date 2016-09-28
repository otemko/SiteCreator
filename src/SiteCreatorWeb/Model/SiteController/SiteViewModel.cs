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
        public string UserNick { get; set; }
        public virtual IEnumerable<string> Tags { get; set; }

        public SiteViewModel(Site site, IEnumerable<Tag> tags)
        {
            Id = site.Id;
            DateCreated = site.DateCreated;
            Name = site.Name;

            UserNick = site.User.UserName;

            var listTags = new List<string>();

            foreach (var tag in tags)
            {
                listTags.Add(tag.Name);
            }

            Tags = listTags;
        }
    }
}
