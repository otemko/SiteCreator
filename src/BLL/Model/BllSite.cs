using DAL.ORM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Model
{
    public class BllSite
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public string Name { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public int StyleMenuId { get; set; }
    }

    public static class BllSiteHelper
    {
        public static BllSite ToBll(this Site site)
        {
            return new BllSite
            {
                Id = site.Id,
                DateCreated = site.DateCreated,
                Name = site.Name,
                UserId = site.UserId,
                StyleMenuId = site.StyleMenuId,
                UserName = site.User.UserName
            };
        }

        public static Site ToDal(this BllSite site)
        {
            return new Site
            {
                DateCreated = site.DateCreated,
                Name = site.Name,
                UserId = site.UserId,
                StyleMenuId = site.StyleMenuId
            };
        }
    }
}
