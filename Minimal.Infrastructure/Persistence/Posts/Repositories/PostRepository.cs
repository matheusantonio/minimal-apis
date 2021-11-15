using Minimal.Domain.Core.Pagination;
using Minimal.Domain.Posts.Entities;
using Minimal.Domain.Posts.Repositories;
using Minimal.Infrastructure.Persistence.Core.EntityFramework;
using Minimal.Infrastructure.Persistence.Core.Extensions;

namespace Minimal.Infrastructure.Persistence.Posts.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly PostsContext _context;

        public PostRepository(PostsContext context)
        {
            _context = context;
        }

        public Post GetById(Guid id)
        {
            return _context.Posts.FirstOrDefault(p => p.Id == id);
        }

        public PaginatedList<Post> GetPosts(int page, int limit)
        {
            return _context.Posts.Paginate(page, limit);
        }

        public void Remove(Post post)
        {
            _context.Posts.Remove(post);
            _context.SaveChanges();
        }

        public void Save(Post post)
        {
            _context.Posts.Add(post);
            _context.SaveChanges();
        }

        public void Update(Post post)
        {
            _context.SaveChanges();
        }
    }
}
