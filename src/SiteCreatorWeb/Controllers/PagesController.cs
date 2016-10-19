using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SiteCreator.BLL.IService;
using Microsoft.AspNetCore.Identity;
using SiteCreator.Entities;
using SiteCreator.Web.Model.PageController;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using SiteCreator.Web.Model.Shared;
using System.Net;

namespace SiteCreator.Web.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class PagesController : Controller
    {
        private IPageService pageService;
        private ISiteService siteService;
        private IUserService userService;

        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public PagesController(IPageService pageService, ISiteService siteService,
            UserManager<User> userManager, SignInManager<User> signInManager, IUserService userService)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.pageService = pageService;
            this.siteService = siteService;
            this.userService = userService;
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<PageViewModel> GetPage(int id)
        {
            var page = await pageService.GetPageWithUserAndContentAndComments(id);
            if (page == null) return null;

            return new PageViewModel(page);
        }

        [HttpPost]
        public async Task<IActionResult> PostPage([FromBody] PageViewModel pageViewModel)
        {
            if (pageViewModel == null) return BadRequest();
            var site = await siteService.GetSingleAsync(pageViewModel.SiteId);

            if (!CheckTheRights(site)) return Unauthorized();
            if (! await CheckLockout()) return StatusCode((int)HttpStatusCode.Forbidden);

            var page = pageViewModel.CreateBllPage();
            await pageService.CreateAsync(page);
            return Ok(page.Id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPage(int id, [FromBody]PageViewModel pageViewModel)
        {
            var page = await pageService.GetPageWithSiteAndContent(id);
            if (!CheckPageForUpdate(page, pageViewModel)) return BadRequest();
            if (!CheckTheRights(page?.Site)) return Unauthorized();
            if (!await CheckLockout()) return StatusCode((int)HttpStatusCode.Forbidden);

            page = pageViewModel.UpdateBllPage(page);
            await pageService.UpdateAsync(page);

            return Ok();
        }

        [HttpPut("{id}/{rating}")]
        public async Task<IActionResult> Vote(int id, int rating)
        {
            var page = await pageService.GetPageWithSite(id);
            if (page == null) return BadRequest();
            if (rating > 5 || rating < 0) return BadRequest();
            if (!CheckTheRightsForVote(page?.Site)) return BadRequest();
            if (!await CheckLockout()) return StatusCode((int)HttpStatusCode.Forbidden);

            pageService.Vote(page, rating);

            return Ok(new { page.Rating, page.CountRated });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var page = await pageService.GetPageWithSite(id);
            if (page == null) return BadRequest();

            if (!CheckTheRights(page?.Site)) return Unauthorized();
            if (!await CheckLockout()) return StatusCode((int)HttpStatusCode.Forbidden);

            await pageService.DeleteAsync(page);
            return Ok();
        }

        private bool CheckTheRights(Site site)
        {
            if (User.IsInRole("Admin"))
                return true;

            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (site != null && site.UserId == userId)
                return true;
            
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

        private bool CheckTheRightsForVote(Site site)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (site != null && site.UserId != userId)
                return true;

            return false;
        }

        private bool CheckPageForUpdate(Page page, PageViewModel pageViewModel)
        {
            if (page != null && page.SiteId == pageViewModel.SiteId) return true;
            return false;
        }
    }
}
