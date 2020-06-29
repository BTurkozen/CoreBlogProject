using CoreBlogProject.Interfaces;
using CoreBlogProject.Models;
using CoreBlogProject.Models.Comment;
using CoreBlogProject.Repositories;
using CoreBlogProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using cloudscribe.Pagination.Models;
using CoreBlogProject.Data;
using Microsoft.EntityFrameworkCore;

namespace CoreBlogProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPostRepository _postRepository;
        private readonly IFileManager _fileManager;
        private readonly ApplicationDbContext _dbContext;

        public HomeController(ILogger<HomeController> logger, IPostRepository postRepository, IFileManager fileManager, ApplicationDbContext dbContext)
        {
            _logger = logger;
            _postRepository = postRepository;
            _fileManager = fileManager;
            _dbContext = dbContext;
            var comment = new MainComment();

        }

        public IActionResult Index(int pagenumber = 1, int pageSize = 5)
        {
            int totalPage = (pagenumber * pageSize) - pageSize;
            var post = _dbContext.Posts.Include(c => c.Category).Skip(totalPage).Take(pageSize);
            var result = new PagedResult<Post>
            {
                Data = post.AsNoTracking().ToList(),
                TotalItems = _dbContext.Posts.Count(),
                PageNumber = pagenumber,
                PageSize = pageSize
            };
            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Comment(CommentViewModel cvm)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Post", new { Id = cvm.PostId });

            var post = _postRepository.GetPostId(cvm.PostId);
            if (cvm.MainCommentId == 0)
            {
                post.MainComments = post.MainComments ?? new List<MainComment>();
                post.MainComments.Add(new MainComment
                {
                    PostId = cvm.PostId,
                    Message = cvm.Message,
                    CreateTime = DateTime.Now

                });
                _postRepository.UpdatePost(post);
                return RedirectToAction("Details");
            }
            else
            {
                var comment = new SubComment
                {
                    MainCommentId = cvm.MainCommentId,
                    Message = cvm.Message,
                    CreateTime = DateTime.Now
                };
                _postRepository.AddComment(comment);
            }
            await _postRepository.SaveChangesAsync();

            return View();
        }

        public IActionResult Details(int id)
        {
            var post = _postRepository.GetPostId(id);
            return View(post);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpGet("/Images/{image}")]
        public IActionResult Image(string image)
        {
            var mime = image.Substring(image.LastIndexOf('.') + 1);
            return new FileStreamResult(_fileManager.ImageStream(image), $"image{mime}"); //
        }
    }
}
