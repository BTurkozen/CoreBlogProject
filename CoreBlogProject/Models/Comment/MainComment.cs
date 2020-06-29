using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBlogProject.Models.Comment
{
    public class MainComment : Comment
    {
        [ForeignKey("Post")]
        public int PostId { get; set; }

        public Post Post { get; set; }
        public List<SubComment> SubComments { get; set; }
    }
}
