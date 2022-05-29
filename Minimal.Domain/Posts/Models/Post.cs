using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minimal.Domain.Posts.Models
{
    public class Post
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime DateOfPublication { get; set; }
        public DateTime DateOfLastAlteration { get; set; }
        private Post() { }
    }
}
