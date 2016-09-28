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
    [Route("api/[controller]")]
    public class SitesController : Controller
    {
        private ISiteService siteService;

        public SitesController(ISiteService siteService)
        {
            this.siteService = siteService;
        }

        // GET: api/values
        [HttpGet]
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

        [HttpGet("{id}")]
        public async Task<IEnumerable<SiteViewModel>> Get(string id)
        {
            var listResult = new List<SiteViewModel>();

            var sites = await siteService.GetSitesWithUserAndTag(id);

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
