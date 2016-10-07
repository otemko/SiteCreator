using SiteCreator.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteCreator.Web.Model.PageController
{
    public class CommentViewModel
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public int PageId { get; set; }

        public CommentViewModel() { }

        public CommentViewModel(Comment comment)
        {
            Id = comment.Id;
            Content = comment.Content;
            UserId = comment.UserId;
            UserName = comment.User?.UserName;
            PageId = comment.PageId;
        }

        public Comment CreateBllComment()
        {
            return new Comment
            {
                Content = Content,
                UserId = UserId,
                PageId = PageId,
            };
        }

        public Comment UpdateBllComment(Comment comment)
        {
            comment.Content = Content;
            return comment;
        }

    }
}
