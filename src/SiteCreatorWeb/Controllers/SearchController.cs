using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SiteCreator.BLL.IService;
using SiteCreator.Web.Model.SearchController;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SiteCreator.Web.Controllers
{
    [Route("api/[controller]")]
    public class SearchController : Controller
    {
        private ISearchService searchService;

        public SearchController(ISearchService searchService)
        {
            this.searchService = searchService;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("{searchTerm}")]

        public void Get(string searchTerm)
        {
            
        }

        // POST api/values
        [HttpPost]
        public SearchResultViewModel Post([FromBody]string searchTerm)
        {
            return new SearchResultViewModel
            {
                SearchSites = GetSitesViewModel(searchTerm),
                SearchPages = GetPagesViewModel(searchTerm),
                SearchUsers = GetUsersViewModel(searchTerm)
            };
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

        private List<SearchSiteViewModel> GetSitesViewModel(string searchTerm)
        {
            var resultSites = new List<SearchSiteViewModel>();

            var sitesBySiteName = searchService.GetSitesBySiteName(searchTerm).ToList();
            sitesBySiteName.ForEach(s => resultSites.Add(new SearchSiteViewModel(s)));

            var sitesByTagName = searchService.GetSitesByTagName(searchTerm).ToList();
            sitesByTagName.ForEach(s => resultSites.Add(new SearchSiteViewModel(s)));

            return resultSites;
        }

        private List<SearchPageViewModel> GetPagesViewModel(string searchTerm)
        {
            var resultPages = new List<SearchPageViewModel>();

            var pagesByComment = searchService.GetPagesByComment(searchTerm).ToList();
            pagesByComment.ForEach(p => resultPages.Add(new SearchPageViewModel(p)));

            var pagesByContent = searchService.GetPagesByContent(searchTerm).ToList();
            pagesByContent.ForEach(p => resultPages.Add(new SearchPageViewModel(p)));

            return resultPages;
        }

        private List<SearchUserViewModel> GetUsersViewModel(string searchTerm)
        {
            var resultUsers = new List<SearchUserViewModel>();

            var usersByUserName = searchService.GetUsersByUserName(searchTerm).ToList();
            usersByUserName.ForEach(u => resultUsers.Add(new SearchUserViewModel(u)));

            return resultUsers;
        }
    }
}
