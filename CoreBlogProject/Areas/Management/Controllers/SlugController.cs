using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreBlogProject.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace CoreBlogProject.Areas.Management.Controllers
{
    [Area("Management")]
    [Route("Management/[controller]/[action]")]
    public class SlugController : Controller
    {
        [HttpPost]
        public string ConvertToSlug(string title)
        {
            return UrlServices.URLFriendly(title);
        }
    }
}
