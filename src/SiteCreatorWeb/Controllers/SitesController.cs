using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using SiteCreator.BLL.IService;
using SiteCreator.Entities;
using System.Linq;
using SiteCreator.Web.Model.SiteController;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using System.Net;
using System.Net.Http;

namespace SiteCreator.Web.Controllers
{
    [Authorize]
    public class SitesController : Controller
    {
        private IUserService userService;
        private ISiteService siteService;
        private ITagService tagService;

        private readonly UserManager<User> userManager;

        public SitesController(ISiteService siteService,
            ITagService tagService,
            IUserService userService,
            UserManager<User> userManager)
        {
            this.userManager = userManager;
            this.siteService = siteService;
            this.tagService = tagService;
            this.userService = userService;
        }

        [HttpGet]
        [Route("api/[controller]")]
        [AllowAnonymous]
        public async Task<IEnumerable<SiteViewModel>> GetAllSites()
        {
            var sites = await siteService.GetAllSitesWithUserAndTag();
            var result = GetSitesViewModel(sites);
            return result;
        }

        [HttpGet]
        [Route("api/[controller]/{userId}")]
        [AllowAnonymous]
        public async Task<IEnumerable<SiteViewModel>> GetSitesByUser(string userId)
        {
            var sites = await siteService.GetSitesByUserId(userId);
            var result = GetSitesViewModel(sites);
            return result;
        }

        [HttpGet]
        [Route("api/[controller]/{tagId:int}")]
        [AllowAnonymous]
        public async Task<IEnumerable<SiteViewModel>> GetSitesByTagId(int tagId)
        {
            var sites = await siteService.GetSitesByTagId(tagId);
            var result = GetSitesViewModel(sites);
            return result;
        }

        [HttpGet]
        [Route("api/[controller]/siteId/{siteId:int}")]
        [AllowAnonymous]
        public async Task<SiteViewModel> GetSite(int siteId)
        {
            var site = await siteService.GetSitesById(siteId);
            var result = site == null ? null : new SiteViewModel(site);
            return result;
        }

        [HttpPost]
        [Route("api/[controller]")]
        public async Task<IActionResult> Post([FromBody]CreateSiteViewModel createSite)
        {
            if (createSite == null) return BadRequest();
            var site = createSite.createBllSite();
            if (!await CheckTheRights(site)) return Unauthorized();
            if (!await CheckLockout())
                return StatusCode((int)HttpStatusCode.Forbidden);

            var tags = await SaveTagsToDb(createSite);
            await siteService.CreateSiteWithTagsAsync(site, tags);

            return Ok(site.Id);
        }

        [HttpPut]
        [Route("api/[controller]")]
        public async Task<IActionResult> Put([FromBody] CreateSiteViewModel createSite)
        {
            if (createSite == null) return BadRequest();
            var site = await siteService.GetSitesById(createSite.id);
            if (site == null) return BadRequest();
            if (!await CheckTheRights(site)) return Unauthorized();
            if (!await CheckLockout()) return StatusCode((int)HttpStatusCode.Forbidden);

            createSite.UpdateBllSite(site);
            var tags = await SaveTagsToDb(createSite);
            await siteService.UpdateSiteWithTagsAsync(site, tags);

            return Ok();
        }

        [HttpDelete]
        [Route("api/[controller]/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var site = await siteService.GetSingleAsync(id);
            if (site == null) return Ok();
            if (!await CheckTheRights(site)) return Unauthorized();
            if (!await CheckLockout()) return StatusCode((int)HttpStatusCode.Forbidden);

            await siteService.DeleteAsync(site);
            return Ok();
        }

        async Task<bool> CheckTheRights(Site site)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await userService.GetSingleAsync(userId);
            if (site.UserId == userId || await userManager.IsInRoleAsync(user, "admin")) return true;

            return false;
        }

        private async Task<bool> CheckLockout()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await userService.GetSingleAsync(userId);
            if (user.LockoutEnabled)
                return true;

            return false;
        }

        async Task<List<Tag>> SaveTagsToDb(CreateSiteViewModel createSite)
        {
            List<Tag> tags = new List<Tag>();
            createSite.tags.ToList().ForEach(p => tags.Add(p.GetBllTag()));
            var tagsFromDb = await tagService.CreateTags(tags);
            return tagsFromDb.ToList();
        }

        IEnumerable<SiteViewModel> GetSitesViewModel(IEnumerable<Site> sites)
        {
            if (sites == null) return null;
            var listResult = new List<SiteViewModel>();

            foreach (var site in sites)
            {
                var tags = site.TagSite.Select(t => t.Tag);
                listResult.Add(new SiteViewModel(site, tags));
            }
            return listResult;
        }
    }
}
