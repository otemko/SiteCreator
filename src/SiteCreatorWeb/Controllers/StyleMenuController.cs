using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SiteCreator.Web.Model.StyleMenuController;
using SiteCreator.BLL.IService;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SiteCreator.Web.Controllers
{
    [Route("api/[controller]")]
    public class StyleMenuController : Controller
    {

        private IStyleMenuService styleMenuService;

        public StyleMenuController(IStyleMenuService styleMenuService)
        {
            this.styleMenuService = styleMenuService;
        }

        // GET: api/values
        [HttpGet]
        public async Task<IEnumerable<StyleMenuViewModel>> Get()
        {
            var listResult = new List<StyleMenuViewModel>();

            var styleMenus = await styleMenuService.GetAllAsync();

            foreach (var item in styleMenus)
            {
                listResult.Add(new StyleMenuViewModel(item));
            }

            return listResult;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
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
