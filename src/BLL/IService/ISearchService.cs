﻿using SiteCreator.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteCreator.BLL.IService
{
    public interface ISearchService
    {
        ICollection<Site> GetSitesByTagName(string searchTerm);
        ICollection<Site> GetSitesBySiteName(string searchTerm);
        ICollection<User> GetUsersByUserName(string searchTerm);
        ICollection<Page> GetPagesByContent(string searchTerm);
        ICollection<Page> GetPagesByComment(string searchTerm);
    }
}
