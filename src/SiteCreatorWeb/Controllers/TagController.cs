using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SiteCreator.BLL.IService;
using SiteCreator.Web.Model.Shared;

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

        [HttpGet]
        public async Task<IEnumerable<TagViewModel>> Get()
        {
            var listResult = new List<TagViewModel>();

            var tags = await tagService.GetAllNonRepeatTagsAsync();

            foreach (var item in tags)
                listResult.Add(new TagViewModel(item));

            return listResult;
        }
    }
}
