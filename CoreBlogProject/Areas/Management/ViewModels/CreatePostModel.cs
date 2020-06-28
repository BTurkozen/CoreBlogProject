using CoreBlogProject.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBlogProject.Areas.Management.ViewModels
{
    public class CreatePostModel
    {
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public IFormFile PhotoPath { get; set; }
        public string Slug { get; set; }

    }
}
