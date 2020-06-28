using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreBlogProject.Areas.Management.ViewModels;
using CoreBlogProject.Data;
using CoreBlogProject.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CoreBlogProject.Areas.Management.Controllers
{
    [Area("Management")]
    [Route("Management/[controller]/[action]")]
    public class ManagementController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public ManagementController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            var dvm = new ManagementViewModel
            {
                CategoryCount = _dbContext.Categories.Count(),
                PostCount = _dbContext.Posts.Count(),
                UserCount = _dbContext.Users.Count()
            };
            return View(dvm);
        }
    }
}
