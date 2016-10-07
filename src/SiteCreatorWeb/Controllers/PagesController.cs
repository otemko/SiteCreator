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

namespace SiteCreator.Web.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class PagesController : Controller
    {
        private IPageService pageService;
        private ISiteService siteService;

        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public PagesController(IPageService pageService, ISiteService siteService,
            UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.pageService = pageService;
            this.siteService = siteService;
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
            var site = await siteService.GetSingleAsync(pageViewModel.SiteId);
            if (!CheckTheRights(site)) return Unauthorized();

            var page = pageViewModel.CreateBllPage();
            return Ok(await pageService.CreateAsync(page));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPage(int id, [FromBody]PageViewModel pageViewModel)
        {
            var page = await pageService.GetPageWithSiteAndContent(id);
            if (!CheckPageForUpdate(page, pageViewModel)) return BadRequest();
            if (!CheckTheRights(page?.Site)) return Unauthorized();

            page = pageViewModel.UpdateBllPage(page);
            await pageService.UpdateAsync(page);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var page = await pageService.GetPageWithSite(id);
            if (page == null) return BadRequest();

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

        private bool CheckPageForUpdate(Page page, PageViewModel pageViewModel)
        {
            if (page != null && page.SiteId == pageViewModel.SiteId) return true;
            return false;
        }
    }
}
