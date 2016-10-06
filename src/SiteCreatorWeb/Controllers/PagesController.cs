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
            var page = await pageService.GetPageWithUserAndComments(id);
            if (page == null) return null;

            return new PageViewModel(page);
        }

        [HttpPost]
        public async Task<int> PostPage([FromBody] PageViewModel pageViewModel)
        {
            if (!await CheckTheRights(pageViewModel.SiteId)) throw new UnauthorizedAccessException();

            var page = pageViewModel.CreateBllPage();
            return await pageService.CreateAsync(page);
        }

        private async Task<bool> CheckTheRights(int siteId)
        {
            if (User.IsInRole("Admin"))
                return true;

            var site = await siteService.GetSingleAsync(siteId);
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (site != null && site.UserId == userId)
                return true;
            
            return false;
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
