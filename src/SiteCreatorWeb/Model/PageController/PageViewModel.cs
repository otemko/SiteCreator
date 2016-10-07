using SiteCreator.Entities;
using SiteCreator.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SiteCreator.Web.Model.PageController
{
    public class PageViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Preview { get; set; }
        public int Order { get; set; }
        public decimal Rating { get; set; }
        public int CountRated { get; set; }
        public DateTime LastModification { get; set; }
        public int SiteId { get; set; }
        public string SiteName { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Content { get; set; }
        public bool CommentsEnabled { get; set; }
        public virtual List<CommentViewModel> Comments { get; set; }

        public PageViewModel() { }

        public PageViewModel(Page page)
        {
            Id = page.Id;
            Name = page.Name;
            Preview = page.Preview;
            Order = page.Order;
            Rating = page.Rating;
            CountRated = page.CountRated;
            LastModification = page.LastModififcation;
            SiteId = page.SiteId;
            SiteName = page.Site?.Name;
            UserId = page.Site?.UserId;
            UserName = page.Site?.User?.UserName;
            Content = page.PageContent.Content;
            CommentsEnabled = page.CommentsEnabled;

            if (CommentsEnabled)
            {
                Comments = new List<CommentViewModel>();
                page.Comment.ToList().ForEach(p => Comments.Add(new CommentViewModel(p)));
            }
        }

        public Page CreateBllPage()
        {
            Page page = new Page()
            {
                Name = Name,
                Preview = Preview,
                Order = Order,
                LastModififcation = DateTime.Now,
                SiteId = SiteId,
                PageContent = new PageContent { Content = Content },
                CommentsEnabled = CommentsEnabled
            };
            return page;
        }

        public Page UpdateBllPage(Page page)
        {
            page.Name = Name;
            page.Preview = Preview;
            page.Order = Order;
            page.LastModififcation = DateTime.Now;
            page.PageContent.Content = Content;
            page.CommentsEnabled = CommentsEnabled;

            return page;
        }
    }
}
