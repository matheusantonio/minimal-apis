using Minimal.Domain.Core.Pagination;
using Minimal.Domain.Posts.Entities;

namespace Minimal.Domain.Posts.Repositories
{
    public interface IPostRepository
    {
        PaginatedList<Post> GetPosts(int page, int limit);
        Post GetById(Guid id);
        void Save(Post post);
        void Update(Post post);
        void Remove(Post post);
    }
}
