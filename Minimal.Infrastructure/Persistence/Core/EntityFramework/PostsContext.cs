using Microsoft.EntityFrameworkCore;
using Minimal.Domain.Posts.Entities;
using Minimal.Domain.Posts.Models;

namespace Minimal.Infrastructure.Persistence.Core.EntityFramework
{
    public  class PostsContext : DbContext
    {
        public PostsContext(DbContextOptions options) : base(options) { }

        public DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Post>()
                .HasKey(x => x.Id);
            base.OnModelCreating(builder);
        }
    }
}
