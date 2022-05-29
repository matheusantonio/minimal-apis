using Minimal.Domain.Core.Pagination;
using Minimal.Domain.Posts.Entities;
using Minimal.Domain.Posts.Models;
using Minimal.Domain.Posts.Repositories;

namespace Minimal.Domain.Posts.Services
{
    public interface IPostService
    {
        ServiceResult<PaginatedList<PostDomain>> GetPosts(int page, int limit);

        ServiceResult<PostDomain> GetPost(Guid id);

        ServiceResult CreatePost(SavePost createPost);

        ServiceResult AlterPost(SavePost alterPost);

        ServiceResult DeletePost(Guid id);
    }

    public class PostService : IPostService
    {
        private readonly IPostRepository _repository;

        public PostService(IPostRepository repository)
        {
            _repository = repository;
        }

        public ServiceResult<PaginatedList<PostDomain>> GetPosts(int page, int limit)
        {
            var result = _repository.GetPosts(page, limit);

            return new ValidResult<PaginatedList<PostDomain>>(result);
        }

        public ServiceResult<PostDomain> GetPost(Guid id)
        {
            var result = _repository.GetById(id);

            return new ValidResult<PostDomain>(result);
        }

        public ServiceResult CreatePost(SavePost createPost)
        {
            if(_repository.PostExists(createPost.Id))
            {
                return new InvalidResult("Post already exists");
            }

            var post = new PostDomain(createPost);

            _repository.Save(post);

            return new ValidResult("Post created");
        }

        public ServiceResult AlterPost(SavePost alterPost)
        {
            var post = _repository.GetById(alterPost.Id);

            if(post == null)
            {
                return new InvalidResult("Post not found");
            }

            post.AlterPost(alterPost);

            _repository.Update(post);

            return new ValidResult("Post altered");
        }

        public ServiceResult DeletePost(Guid id)
        {
            var post = _repository.GetById(id);

            if (post == null)
            {
                return new InvalidResult("Post not found");
            }

            _repository.Remove(post);

            return new ValidResult("Post removed");
        }
    }
}
