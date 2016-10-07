using SiteCreator.Entities;
using SiteCreator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteCreator.Web.Model.Shared
{
    public class PageInfoViewModel
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
        public bool CommentsEnabled { get; set; }


        public PageInfoViewModel() { }

        public PageInfoViewModel(Page page)
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
            CommentsEnabled = page.CommentsEnabled;
        }
        
    }
}
