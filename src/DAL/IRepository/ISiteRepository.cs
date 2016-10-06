using SiteCreator.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteCreator.DAL.IRepository
{
    public interface ISiteRepository
    {
        Task<IEnumerable<Site>> GetSitesWithUsersAndTagsByTagId(int tagId);
    }
}
