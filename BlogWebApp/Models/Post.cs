using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogWebApp.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string PostTitle { get; set; }
        public string PostContent { get; set; }
        public string PostAuthor { get; set; }
        public DateTime PostDate { get; set; }
    }
}
