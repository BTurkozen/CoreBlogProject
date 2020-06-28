using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBlogProject.Areas.Management.ViewModels
{
    public class ManagementViewModel
    {
        public int CategoryCount { get; set; }
        public int PostCount { get; set; }
        public int UserCount { get; set; }
        public int CommentCount { get; set; }
    }
}
