using Minimal.Domain.Posts.Models;

namespace Minimal.Domain.Posts.Entities
{
    public class PostDomain
    {
        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public string Content { get; private set; }
        public DateTime DateOfPublication { get; private set; }
        public DateTime DateOfLastAlteration { get; private set; }

        private PostDomain() {}

        public PostDomain(SavePost registerPost)
        {
            Id = registerPost.Id;
            Title = registerPost.Title;
            Content = registerPost.Content;
            DateOfPublication = DateTime.Now;
            DateOfLastAlteration = DateOfPublication;
        }

        public void AlterPost(SavePost alterPost)
        {
            Title = alterPost.Title;
            Content=alterPost.Content;
            DateOfLastAlteration=DateTime.Now;
        }
    }
}
