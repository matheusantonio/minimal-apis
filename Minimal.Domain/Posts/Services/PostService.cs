using Minimal.Domain.Core.Pagination;
using Minimal.Domain.Posts.Entities;
using Minimal.Domain.Posts.Models;
using Minimal.Domain.Posts.Repositories;

namespace Minimal.Domain.Posts.Services
{
    public interface IPostService
    {
        PaginatedList<Post> GetPosts(int page, int limit);

        Post GetPost(Guid id);

        void CreatePost(SavePostModel createPost);

        void AlterPost(SavePostModel alterPost);

        void DeletePost(Guid id);
    }

    public class PostService : IPostService
    {
        private readonly IPostRepository _repository;

        public PostService(IPostRepository repository)
        {
            _repository = repository;
        }

        public PaginatedList<Post> GetPosts(int page, int limit)
        {
            return _repository.GetPosts(page, limit);
        }

        public Post GetPost(Guid id)
        {
            return _repository.GetById(id);
        }

        public void CreatePost(SavePostModel createPost)
        {
            var post = new Post(createPost);

            _repository.Save(post);
        }

        public void AlterPost(SavePostModel alterPost)
        {
            var post = _repository.GetById(alterPost.Id);

            post.AlterPost(alterPost);

            _repository.Update(post);
        }

        public void DeletePost(Guid id)
        {
            var post = _repository.GetById(id);

            _repository.Remove(post);
        }
    }
}
