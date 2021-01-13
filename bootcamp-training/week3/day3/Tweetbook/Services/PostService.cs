using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OpenXmlPowerTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tweetbook.Data;
using Tweetbook.Domain;

namespace Tweetbook.Services
{
    public class PostService : IPostservice
    {
        private readonly DataContext _datacontext;

        public PostService(DataContext datacontext)
        {
            _datacontext = datacontext;
        }

       

        public async Task<bool> DeletePostAsync(Guid postId)
        {
            var post = await GetPostByIdAsync(postId);
            _datacontext.posts.Remove(post);
            var deleted=await _datacontext.SaveChangesAsync();

            return deleted>0;
        }

        public async Task<Post> GetPostByIdAsync(Guid postId)
        {
          
            return await _datacontext.posts.SingleOrDefaultAsync(X => X.ID == postId);
        }

        public async Task<List<Post>> GetPostsasync()
        {
            return await _datacontext.posts.ToListAsync();
        }

        public async Task<bool> UpdatePostAsync(Post postToUpdate)
        {
            _datacontext.posts.Update(postToUpdate);
            var updated = await _datacontext.SaveChangesAsync();
           
            return updated>0;

        }

        public async Task<bool> CreatePostAsync(Post post)
        {
            await _datacontext.posts.AddAsync(post);
            var created = await _datacontext.SaveChangesAsync();
            return created > 0;
        }
    }
}
