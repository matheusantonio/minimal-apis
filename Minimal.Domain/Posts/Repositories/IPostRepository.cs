using Minimal.Domain.Core.Pagination;
using Minimal.Domain.Posts.Entities;

namespace Minimal.Domain.Posts.Repositories
{
    public interface IPostRepository
    {
        PaginatedList<PostDomain> GetPosts(int page, int limit);
        PostDomain GetById(Guid id);

        bool PostExists(Guid id);
        void Save(PostDomain post);
        void Update(PostDomain post);
        void Remove(PostDomain post);
    }
}
