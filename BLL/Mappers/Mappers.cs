using BLL.Model;
using DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Mappers
{
    public static class Mappers
    {

        public static BllSite ToBll(this DalSite dalSite)
        {
            return new BllSite
            {
                Id = dalSite.Id,
                DateCreated = dalSite.DateCreated,
                Name = dalSite.Name,
                UserId = dalSite.UserId,
                StyleMenuId = dalSite.StyleMenuId,
                //UserName = dalSite.User.UserName
            };
        }

        public static DalSite ToDal(this BllSite bllSite)
        {
            return new DalSite
            {
                DateCreated = bllSite.DateCreated,
                Name = bllSite.Name,
                UserId = bllSite.UserId,
                StyleMenuId = bllSite.StyleMenuId
            };
        }
    }
}
