using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreBlogProject.Areas.Management.ViewModels;
using CoreBlogProject.Helpers;
using CoreBlogProject.Interfaces;
using CoreBlogProject.Models;
using CoreBlogProject.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CoreBlogProject.Areas.Management.Controllers
{
    [Area("Management")]
    [Route("Management/[controller]/[action]")]
    //[Authorize]
    public class PostsController : Controller
    {
        private readonly IPostRepository _postRepository;
        private readonly IFileManager _file;
        private readonly ICategoryRepository _categoryRepository;

        public PostsController(IPostRepository postRepository, IFileManager file, ICategoryRepository categoryRepository)
        {
            _postRepository = postRepository;
            _file = file;
            _categoryRepository = categoryRepository;
        }

        public IActionResult Index()
        {
            return View(_postRepository.AllPosts);
        }

     

        public IActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(_categoryRepository.AllCategories.OrderBy(x => x.CategoryName), "CategoryId", "CategoryName");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreatePostModel cpm)
        {
            if (ModelState.IsValid)
            {
                Post newPost = new Post
                {
                    CategoryId = cpm.CategoryId,
                    Title = cpm.Title,
                    Content = cpm.Content,
                    PhotoPath = await _file.SaveImages(cpm.PhotoPath),
                    Slug = UrlServices.URLFriendly(cpm.Slug),
                    AddTime = DateTime.Now,
                    EditTime = DateTime.Now
                };
                _postRepository.CreatePost(newPost);
                if (await _postRepository.SaveChangesAsync())
                {
                    return RedirectToAction("Index");
                }

            }
            //Dropddown'da category name cagırmak için category ıd cagırılacak
           ViewBag.CategoryId = new SelectList(_categoryRepository.AllCategories.OrderBy(x => x.CategoryName), "CategoryId", "CategoryName");
            return View();
        }


        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return View(new Post());
            }
            var post = _postRepository.GetPostId((int)id);
            if (post == null)
            {
                return NotFound();
            }
            ViewBag.CategoryId = new SelectList(_categoryRepository.AllCategories.OrderBy(x => x.CategoryName), "CategoryId", "CategoryName");
            return View(post);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Post post)
        {
            if (post.PostId > 0)
            {
                if (post.PhotoPath != null)
                {
                    _file.DeleteImage(post.PhotoPath);
                }
                
                _postRepository.UpdatePost(post);
            }

            _postRepository.CreatePost(post);

            if (await _postRepository.SaveChangesAsync())
            {
                return RedirectToAction(nameof(Index));
            }
            ViewBag.CategoryId = new SelectList(_categoryRepository.AllCategories.OrderBy(x => x.CategoryName), "CategoryId", "CategoryName");
            return View(post);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            _postRepository.DeletePost(id);
            await _postRepository.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
