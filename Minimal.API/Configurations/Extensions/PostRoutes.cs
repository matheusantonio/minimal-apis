using Minimal.Domain.Posts.Models;
using Minimal.Domain.Posts.Services;

namespace Minimal.API.Configurations.Extensions
{
    public static class PostRoutes
    {
        public static void MapPostRoutes(this WebApplication app)
        {
            app.MapGet("/post", (int page, int limit, IPostService postService) =>
            {
                return Results.Ok(postService.GetPosts(page, limit));
            })
            .WithName("GetAllPosts");

            app.MapGet("/post/{id}", (Guid id, IPostService postService) =>
            {
                return Results.Ok(postService.GetPost(id));
            })
            .WithName("GetPost");

            app.MapPost("/post", (SavePostModel createPost, IPostService postService) =>
            {
                postService.CreatePost(createPost);
                return Results.Ok();
            })
            .WithName("RegisterPost");

            app.MapPut("/post", (SavePostModel alterPost, IPostService postService) =>
            {
                postService.AlterPost(alterPost);
                return Results.Ok();
            })
            .WithName("AlterPost");

            app.MapDelete("/post/{id}", (Guid id, IPostService postService) =>
            {
                postService.DeletePost(id);
                return Results.Ok();
            })
            .WithName("DeletePost");
        }
    }
}
