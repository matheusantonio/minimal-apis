using AutoMapper;
using Minimal.Domain.Core.Pagination;
using Minimal.Domain.Posts.Entities;
using Minimal.Domain.Posts.Models;
using Minimal.Domain.Posts.Repositories;
using Minimal.Infrastructure.Persistence.Core.EntityFramework;
using Minimal.Infrastructure.Persistence.Core.Extensions;

namespace Minimal.Infrastructure.Persistence.Posts.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly PostsContext _context;
        private readonly IMapper _mapper;

        public PostRepository(PostsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public PostDomain GetById(Guid id)
        {
            var result = _context.Posts.FirstOrDefault(p => p.Id == id);

            return _mapper.Map<PostDomain>(result);
        }

        public PaginatedList<PostDomain> GetPosts(int page, int limit)
        {
            var result = _context.Posts.Paginate(page, limit);
            return _mapper.Map<PaginatedList<PostDomain>>(result);
        }

        public bool PostExists(Guid id)
        {
            return _context.Posts.Any(x => x.Id == id);
        }

        public void Remove(PostDomain post)
        {
            _context.Posts.Remove(_mapper.Map<Post>(post));
            _context.SaveChanges();
        }

        public void Save(PostDomain post)
        {
            _context.Posts.Add(_mapper.Map<Post>(post));
            _context.SaveChanges();
        }

        public void Update(PostDomain post)
        {
            var result = _context.Posts.First(x => x.Id == post.Id);

            result.Title = post.Title;
            result.DateOfPublication = post.DateOfPublication;
            result.DateOfLastAlteration = post.DateOfLastAlteration;
            result.Content = post.Content;

            _context.SaveChanges();
        }
    }
}
