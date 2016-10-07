using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SiteCreator.BLL.IService;
using Microsoft.AspNetCore.Identity;
using SiteCreator.Entities;
using SiteCreator.Web.Model.PageController;
using System.Security.Claims;

namespace SiteCreator.Web.Controllers
{
    [Route("api/[controller]")]
    public class CommentsController : Controller
    {
        private IPageService pageService;
        private ICommentService commentService;

        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public CommentsController(IPageService pageService, ICommentService commentService,
            UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.pageService = pageService;
            this.commentService = commentService;
        }

        [HttpGet("{pageId}")]
        public async Task<IActionResult> GetComments(int pageId)
        {
            var comments = await commentService.GetCommentsForPage(pageId);
            var commentsViewModel = new List<CommentViewModel>();
            comments.ToList().ForEach(p => commentsViewModel.Add(new CommentViewModel(p)));
            return Ok(commentsViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CommentViewModel commentViewModel)
        {
            if (commentViewModel == null) return BadRequest();
            var page = await pageService.GetSingleAsync(commentViewModel.PageId);
            if (!CanCommentPage(page)) return BadRequest();

            var comment = commentViewModel.CreateBllComment();
            await commentService.CreateAsync(comment);
            return Ok(comment.Id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CommentViewModel commentViewModel)
        {
            if (commentViewModel == null) return BadRequest();
            var comment = await commentService.GetSingleAsync(id);
            if (comment == null) return Ok();
            if (!CheckTheRights(comment)) return BadRequest();
            var page = await pageService.GetSingleAsync(commentViewModel.PageId);
            if (!CanCommentPage(page)) return BadRequest();
            

            comment = commentViewModel.UpdateBllComment(comment);
            await commentService.UpdateAsync(comment);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var comment = await commentService.GetSingleAsync(id);
            if (comment == null) return Ok();
            if (!CheckTheRights(comment)) return BadRequest();
            var page = await pageService.GetSingleAsync(comment.PageId);
            if (!CanCommentPage(page)) return BadRequest();

            await commentService.DeleteAsync(comment);
            return Ok();
        }

        private bool CanCommentPage(Page page)
        {
            if (page != null && page.CommentsEnabled) return true;
            return false;
        }

        private bool CheckTheRights(Comment comment)
        {
            if (User.IsInRole("Admin"))
                return true;

            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (comment.UserId == userId)
                return true;

            return false;
        }
    }
}
