using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CoreBlogProject.Models;
using CoreBlogProject.Repositories;
using CoreBlogProject.Interfaces;
using CoreBlogProject.ViewModels;
using CoreBlogProject.Models.Comment;

namespace CoreBlogProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPostRepository _postRepository;
        private readonly IFileManager _fileManager;

        public HomeController(ILogger<HomeController> logger, IPostRepository postRepository, IFileManager fileManager)
        {
            _logger = logger;
            _postRepository = postRepository;
            _fileManager = fileManager;
            var comment = new MainComment();

        }

        public IActionResult Index()
        {
            return View(_postRepository.AllPosts);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Comment(CommentViewModel cvm)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Post", new { id=cvm.PostId });

            var post = _postRepository.GetPostId(cvm.PostId);
            if (cvm.MainCommentId > 0)
            {
                post.MainComments = post.MainComments ?? new List<MainComment>();
                post.MainComments.Add(new MainComment
                {
                    Message = cvm.Message,
                    CreateTime = DateTime.Now

                });
                _postRepository.UpdatePost(post);
            }
            else
            {
                var comment = new SubComment
                {
                    MainCommentId = cvm.MainCommentId,
                    Message = cvm.Message,
                    CreateTime = DateTime.Now
                };
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
