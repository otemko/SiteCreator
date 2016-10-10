using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SiteCreator.Web.Model.SiteController;
using SiteCreator.BLL.IService;
using Microsoft.AspNetCore.Identity;
using SiteCreator.Entities;
using SiteCreator.Web.Model.PageController;
using SiteCreator.Web.Model.Shared;

namespace SiteCreator.Web.Controllers
{
    

    public class HomeController : Controller
    {
        private IPageService pageService;
        private ISiteService siteService;

        public HomeController(ISiteService siteService,
            IPageService pageService)
        {
            this.siteService = siteService;
            this.pageService = pageService;
        }

        [HttpGet]
        [Route("api/[controller]/LastCreatedSites")]
        public async Task<IEnumerable<SiteViewModel>> GetLastCreatedSites()
        {
            var sites = await siteService.GetLastCreatedSites(4, 0);
            return GetSiteViewModelList(sites);
        }

        [HttpGet]
        [Route("api/[controller]/MostCommentedPages")]
        public async Task<IEnumerable<PageInfoViewModel>> GetMostCommentedPage()
        {
            var pages = await pageService.GetMostCommentedPages(4, 0);
            return GetPageViewModelList(pages);
        }

        [HttpGet]
        [Route("api/[controller]/MostRatedPages")]
        public async Task<IEnumerable<PageInfoViewModel>> GetMostRatedPage()
        {
            var pages = await pageService.GetMostRatedPages(4, 0);
            return GetPageViewModelList(pages);
        }

        private IEnumerable<PageInfoViewModel> GetPageViewModelList(IEnumerable<Page> pages)
        {
            var pageViewModel = new List<PageInfoViewModel>();
            pages.ToList().ForEach(p => pageViewModel.Add(new PageInfoViewModel(p)));
            return pageViewModel;
        }

        private IEnumerable<SiteViewModel> GetSiteViewModelList(IEnumerable<Site> sites)
        {
            var siteViewModel = new List<SiteViewModel>();
            sites.ToList().ForEach(p => siteViewModel.Add(new SiteViewModel(p)));
            return siteViewModel;
        }
    }
}
