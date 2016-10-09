using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SiteCreator.Web.Model.UserController;
using SiteCreator.BLL.IService;
using Microsoft.AspNetCore.Identity;
using SiteCreator.Entities;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SiteCreator.Web.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private IUserService userService;

        public UserController(IUserService userService, 
            UserManager<User> userManager,
            SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.userService = userService;
        }

        // GET: api/values
        [HttpGet]
        [AllowAnonymous]
        public async Task<IEnumerable<UserViewModel>> Get()
        {
            var users = await userService.GetAllAsync();
            var result = new List<UserViewModel>();

            foreach (var user in users)
            {
                var roles = await userManager.GetRolesAsync(user);
                result.Add(new UserViewModel(user, roles[0]));                
            }

            return result;
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
        [HttpPut]
        public async Task<IActionResult> PutUsers(int id, [FromBody]UserViewModel[] usersViewModel)
        {
            if (usersViewModel == null) return BadRequest();
            if (!await CheckTheRights()) return Unauthorized();
            foreach (var userViewModel in usersViewModel)
            {
                var user = await userService.GetSingleAsync(userViewModel.Id);
                
                user.LockoutEnabled = userViewModel.IsLockoutEnabled;
                user.UserName = userViewModel.UserName;

                await userManager.UpdateAsync(user);
            }

            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null) return BadRequest();
            if (!await CheckTheRights()) return Unauthorized();

            var user = await userService.GetSingleAsync(id);
            if (user == null) return BadRequest();
            await userManager.DeleteAsync(user);
            return Ok();
        }

        async Task<bool> CheckTheRights()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null) return false;
            var user = await userService.GetSingleAsync(userId);
            if (await userManager.IsInRoleAsync(user, "admin")) return true;

            return false;
        }
    }
}
