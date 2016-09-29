using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SiteCreator.BLL.IService;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using SiteCreator.Web.Model;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SiteCreator.Web.Controllers
{

    [Route("api/[controller]")]
    [Authorize]
    public class ManageController : Controller
    {
        private IUserService userservice;

        public ManageController(IUserService userservice)
        {
            this.userservice = userservice;
        }

        [HttpGet]
        public async Task<UserInfoViewModel> GetUserInfo()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await userservice.GetSingleAsync(userId);
            return new UserInfoViewModel(user);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpGet("{tegName}")]
        public string Get(string tagName)
        {
            return "valu22312e";
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
