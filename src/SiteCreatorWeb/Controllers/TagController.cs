using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SiteCreator.BLL.IService;
using SiteCreator.Web.Model.Shared;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SiteCreator.Web.Controllers
{
    [Route("api/[controller]")]
    public class TagController : Controller
    {

        private ITagService tagService;

        public TagController(ITagService tagService)
        {
            this.tagService = tagService;
        }

        // GET: api/values
        [HttpGet]
        public async Task<IEnumerable<TagViewModel>> Get()
        {
            var listResult = new List<TagViewModel>();

            var tags = await tagService.GetAllAsync();

            foreach (var item in tags)
            {
                listResult.Add(new TagViewModel(item));
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
