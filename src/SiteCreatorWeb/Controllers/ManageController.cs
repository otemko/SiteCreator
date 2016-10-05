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
using SiteCreator.Entities;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SiteCreator.Web.Controllers
{

    [Route("api/[controller]")]
    public class ManageController : Controller
    {
        private IUserService userservice;

        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public ManageController(IUserService userservice, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.userservice = userservice;
        }

        [HttpGet]
        public async Task<UserInfoViewModel> GetUserInfo()
        {
            if (!signInManager.IsSignedIn(User))
                return null;

            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await userservice.GetSingleAsync(userId);
            return new UserInfoViewModel(user);
        }
    }
}
