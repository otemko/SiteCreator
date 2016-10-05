using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using SiteCreator.BLL.IService;
using SiteCreator.Entities;
using SiteCreator.Web.Model;
using System.Linq;
using SiteCreator.Web.Model.SiteController;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System;

namespace SiteCreator.Web.Controllers
{
    public class SitesController : Controller
    {
        private ISiteService siteService;
        private ITagService tagService;
        private ITagSiteService tagSiteService;

        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public SitesController(ISiteService siteService, ITagService tagService, ITagSiteService tagSiteService,
            UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.siteService = siteService;
            this.tagService = tagService;
            this.tagSiteService = tagSiteService;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public async Task<IEnumerable<SiteViewModel>> GetAllSites()
        {
            var listResult = new List<SiteViewModel>();

            var sites = await siteService.GetAllSitesWithUserAndTag();

            foreach (var site in sites)
            {
                var tags = site.TagSite.Select(t => t.Tag);
                listResult.Add(new SiteViewModel(site, tags));
            }

            return listResult;
        }

        [HttpGet]
        [Route("api/[controller]/{userId}")]
        public async Task<IEnumerable<SiteViewModel>> GetSitesByUser(string userId)
        {
            var listResult = new List<SiteViewModel>();

            var sites = await siteService.GetSitesByUserId(userId);

            foreach (var site in sites)
            {
                var tags = site.TagSite.Select(t => t.Tag);
                listResult.Add(new SiteViewModel(site, tags));
            }

            return listResult;
        }

        [HttpGet]
        [Route("api/[controller]/{tagId:int}")]
        public async Task<IEnumerable<SiteViewModel>> GetTags(int tagId)
        {
            var listResult = new List<SiteViewModel>();

            var sites = await siteService.GetSitesByTagId(tagId);

            foreach (var site in sites)
            {
                var tags = site.TagSite.Select(t => t.Tag);
                listResult.Add(new SiteViewModel(site, tags));
            }

            return listResult;
        }

        [HttpGet]
        [Route("api/[controller]/siteId/{siteId:int}")]
        public async Task<SiteViewModel> GetSite(int siteId)
        {
            var site = await siteService.GetSitesById(siteId);
                      
            var tags = site.TagSite.Select(t => t.Tag); 
           
            return new SiteViewModel(site, tags);
        }

        // POST api/values
        [HttpPost]
        [Route("api/[controller]")]
        public int Post([FromBody]CreateSiteViewModel createSite)
        {
            var site = new Site
            {
                Name = createSite.name,
                DateCreated = GetDate(createSite.dateCreated),
                StyleMenuId = createSite.styleMenuId,
                UserId = createSite.userId
            };

            siteService.CreateAsync(site);

            var newTags = new List<Tag>();
            var tagSites = new List<TagSite>();

            if (createSite.newTags != null)
            {
                foreach (var newTag in createSite.newTags)
                {
                    newTags.Add(new Tag
                    {
                        Name = newTag,
                        TagSite = new List<TagSite>()
                    });
                }
                tagService.CreateRangeAsync(newTags.ToArray());

                foreach (var newTag in newTags)
                {
                    tagSites.Add(new TagSite
                    {
                        SiteId = site.Id,
                        TagId = newTag.Id
                    });
                }
            }

            if (createSite.oldTags != null)
            {
                foreach (var oldTag in createSite.oldTags)
                {
                    tagSites.Add(new TagSite
                    {
                        SiteId = site.Id,                        
                        TagId = oldTag.id
                    });
                }
            }

            tagSiteService.CreateRangeAsync(tagSites.ToArray());
                   
            return 0;
        }

        // PUT api/values/5
        [HttpPut]
        [Route("api/[controller]")]
        public async Task<int> Put([FromBody]CreateSiteViewModel createSite)
        {
            var oldTagSites = await tagSiteService.GetTagSitesBySiteId(createSite.id);
            tagSiteService.DeleteRangeAsync(oldTagSites.ToArray());

            var newTags = new List<Tag>();
            var tagSites = new List<TagSite>();

            if (createSite.newTags != null)
            {
                foreach (var newTag in createSite.newTags)
                {
                    newTags.Add(new Tag
                    {
                        Name = newTag,
                        TagSite = new List<TagSite>()
                    });
                }
                tagService.CreateRangeAsync(newTags.ToArray());

                foreach (var newTag in newTags)
                {
                    tagSites.Add(new TagSite
                    {
                        SiteId = createSite.id,
                        TagId = newTag.Id
                    });
                }
            }

            if (createSite.oldTags != null)
            {
                foreach (var oldTag in createSite.oldTags)
                {
                    tagSites.Add(new TagSite
                    {
                        SiteId = createSite.id,
                        TagId = oldTag.id
                    });
                }
            }

            var site = new Site
            {
                Id = createSite.id,
                TagSite = tagSites,
                Name = createSite.name,
                DateCreated = GetDateUpdtae(createSite.dateCreated),
                StyleMenuId = createSite.styleMenuId,
                UserId = createSite.userId
            };

            siteService.UpdateAsync(site);

            return 0;
        }

        // DELETE api/values/5
        [HttpDelete]
        [Route("api/[controller]/{id:int}")]
        public async Task<int> Delete(int id)
        {
            if (!signInManager.IsSignedIn(User))
                return -1;

            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var site = await siteService.GetSingleAsync(id);

            if (site.UserId == userId)
            {
                siteService.DeleteAsync(site);
                return id;
            }
            return -1;
        }

        private DateTime GetDate(string strDate)
        {
            var dateArray = strDate.Split(' ')[0].Split('.');
            var timeArray = strDate.Split(' ')[1].Split('.');
            return new DateTime(int.Parse(dateArray[2]), int.Parse(dateArray[1]), int.Parse(dateArray[0]),
                int.Parse(timeArray[0]), int.Parse(timeArray[1]), int.Parse(timeArray[2]));
        }

        private DateTime GetDateUpdtae(string strDate)
        {
            var dateArray = strDate.Split('T')[0].Split('-');
            var timeArray = strDate.Split('T')[1].Split(':');
            return new DateTime(int.Parse(dateArray[0]), int.Parse(dateArray[1]), int.Parse(dateArray[2]),
                int.Parse(timeArray[0]), int.Parse(timeArray[1]), int.Parse(timeArray[2]));
        }

    }
}
