using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using SiteCreator.BLL.IService;
using SiteCreator.Entities;
using SiteCreator.Web.Model;
using System.Linq;
using SiteCreator.Web.Model.SiteController;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace SiteCreator.Web.Controllers
{
    public class SitesController : Controller
    {
        private ISiteService siteService;

        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public SitesController(ISiteService siteService, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.siteService = siteService;
        }

        [HttpGet]
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

        [HttpGet]
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

        [HttpGet]
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
        [Route("api/[controller]")]
        public int Post([FromBody]CreateSiteViewModel value)
        {
            return 0;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete]
        [Route("api/[controller]/{id:int}")]
        public async Task<int> Delete(int id)
        {
            if (!signInManager.IsSignedIn(User))
                return -1;

            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var site = await siteService.GetSingleAsync(id);

            if (site.UserId == userId)
            {
                siteService.DeleteAsync(site);
                return id;
            }
            return -1;
        }
    }
}
