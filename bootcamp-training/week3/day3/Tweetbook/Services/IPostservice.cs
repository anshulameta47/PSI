using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tweetbook.Domain;

namespace Tweetbook.Services
{
    public interface IPostservice
    {
        Task<List<Post>> GetPostsasync();
        Task<Post> GetPostByIdAsync(Guid postId);
        Task<bool> UpdatePostAsync(Post post);
        Task<bool> DeletePostAsync(Guid postId);
        Task<bool> CreatePostAsync(Post post);
    }
}
