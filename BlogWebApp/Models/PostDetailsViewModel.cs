using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogWebApp.Models
{
    public class PostDetailsViewModel
    {
        public Post Post { get; set; }
        public List<Comment> Comments { get; set; }

        public int PostID { get; set; }
        public string CommentContent { get; set; }
        public string CommentAuthor { get; set; }
        public DateTime CommentDate { get; set; }

    }
}
