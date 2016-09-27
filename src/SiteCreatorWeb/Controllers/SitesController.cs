using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SiteCreator.BLL.Services;
using System.Threading.Tasks;
using System.Linq;

namespace SiteCreator.Web.Controllers
{
    [Route("api/[controller]")]
    public class SitesController : Controller
    {
        private SiteService siteService;

        public SitesController(SiteService siteService)
        {
            this.siteService = siteService;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("{id}")]
        public async Task<IEnumerable<object>> Get(string id)
        {
            return await siteService.GetAllByUserAsync(id);
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
