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
        public SearchResult Post([FromBody]string searchTerm)
        {
            var sites = searchService.GetSitesIdBySiteName(searchTerm);
            var resultSites = new List<SearchSite>();

            foreach (var site in sites)
            {
                resultSites.Add(new SearchSite {
                    Id = site.Id,
                    Name = site.Name
                });
            }

            var tags = searchService.GetTagsIdByTagName(searchTerm);
            var resultTags = new List<SearchTag>();

            foreach (var tag in tags)
            {
                resultTags.Add(new SearchTag
                {
                    Id = tag.Id,
                    Name = tag.Name
                });
            }

            var users = searchService.GetUsersIdByNick(searchTerm);
            var resultUsers = new List<SearchUser>();

            foreach (var user in users)
            {
                resultUsers.Add(new SearchUser
                {
                    Id = user.Id,
                    UserName = user.UserName
                });
            }
            
            return new SearchResult
            {
                SearchSites = resultSites,
                SearchTags = resultTags,
                SearchUsers = resultUsers
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
    }
}
