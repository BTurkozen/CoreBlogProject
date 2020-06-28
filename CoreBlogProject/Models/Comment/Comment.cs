using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBlogProject.Models.Comment
{
    public class Comment
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime? CreateTime { get; set; }
    }
}
