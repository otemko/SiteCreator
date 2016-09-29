﻿using SiteCreator.Entities;
using System;
using System.Collections.Generic;


namespace SiteCreator.Web.Model.SiteController
{
    public class SiteViewModel
    {
        public virtual int Id { get; set; }
        public virtual DateTime DateCreated { get; set; }
        public virtual string Name { get; set; }
        public string UserName { get; set; }
        public string UserId { get; set; }
        public virtual IEnumerable<TagViewModelSite> Tags { get; set; }

        public SiteViewModel(Site site, IEnumerable<Tag> tags)
        {
            Id = site.Id;
            DateCreated = site.DateCreated;
            Name = site.Name;

            UserName = site.User.UserName;
            UserId = site.UserId;

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
