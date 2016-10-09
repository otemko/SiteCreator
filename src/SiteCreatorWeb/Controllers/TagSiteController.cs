using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SiteCreator.BLL.IService;
using SiteCreator.Web.Model.TagSiteController;
using SiteCreator.Entities;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SiteCreator.Web.Controllers
{
    [Route("api/[controller]")]
    public class TagSiteController : Controller
    {
        ITagSiteService tagSiteSevice;

        public TagSiteController(ITagSiteService tagSiteSevice)
        {
            this.tagSiteSevice = tagSiteSevice;
        }
        
        [HttpGet]
        public async Task<IEnumerable<TagSiteViewModel>> Get()
        {
            var tagSites = await tagSiteSevice.GetTagSitesWithTag();
            return GetTagSitesViewModel(tagSites.ToList());            
        }

        private IEnumerable<TagSiteViewModel> GetTagSitesViewModel(List<TagSite> tagSites)
        {
            if (tagSites == null) return null;
            var listResult = new List<TagSiteViewModel>();
            tagSites.ForEach(ts => listResult.Add(new TagSiteViewModel(ts)));
            return listResult;
        }
    }
}
