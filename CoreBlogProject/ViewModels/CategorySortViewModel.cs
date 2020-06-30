using CoreBlogProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBlogProject.ViewModels
{
    public class CategorySortViewModel
    {
        public List<Category> Categories { get; set; }

        public int PostCount { get; set; }
    }
}
