using CoreBlogProject.Models.Comment;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBlogProject.Models
{
    public class Post
    {
        public int PostId { get; set; }

        public int CategoryId { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        public string Content { get; set; }

        public string PhotoPath { get; set; } = "";

        [Required]
        [StringLength(200)]
        public string Slug { get; set; }

        [Required]
        public DateTime? AddTime { get; set; }
        public DateTime? EditTime { get; set; }

        public virtual Category Category { get; set; }

        public List<MainComment> MainComments { get; set; }
    }
}
