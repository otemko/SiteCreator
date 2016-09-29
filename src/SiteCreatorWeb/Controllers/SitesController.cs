using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using SiteCreator.BLL.IService;
using SiteCreator.Entities;
using SiteCreator.Web.Model;
using System.Linq;
using SiteCreator.Web.Model.SiteController;

namespace SiteCreator.Web.Controllers
{
    public class SitesController : Controller
    {
        private ISiteService siteService;

        public SitesController(ISiteService siteService)
        {
            this.siteService = siteService;
        }

        // GET: api/values
        [Route("api/[controller]")]
        public async Task<IEnumerable<SiteViewModel>> Get()
        {
            var listResult = new List<SiteViewModel>();

            var sites = await siteService.GetAllSitesWithUserAndTag();

            foreach (var site in sites)
            {
                var tags = site.TagSite.Select(t => t.Tag);
                listResult.Add(new SiteViewModel(site, tags));
            }

            return listResult;
        }

        [Route("api/[controller]/{userId}")]
        public async Task<IEnumerable<SiteViewModel>> Getstring(string userId)
        {
            var listResult = new List<SiteViewModel>();

            var sites = await siteService.GetSitesByUserId(userId);

            foreach (var site in sites)
            {
                var tags = site.TagSite.Select(t => t.Tag);
                listResult.Add(new SiteViewModel(site, tags));
            }

            return listResult;
        }

        [Route("api/[controller]/{tagId:int}")]
        public async Task<IEnumerable<SiteViewModel>> Getint(int tagId)
        {
            var listResult = new List<SiteViewModel>();

            var sites = await siteService.GetSitesByTagId(tagId);

            foreach (var site in sites)
            {
                var tags = site.TagSite.Select(t => t.Tag);
                listResult.Add(new SiteViewModel(site, tags));
            }

            return listResult;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
