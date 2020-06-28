﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBlogProject.Areas.Management.ViewModels
{
    public class CategoryViewModel
    {
        [Display(Name = "Category Id")]
        public int CategoryId { get; set; }
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }
        public string Slug { get; set; }
    }
}
